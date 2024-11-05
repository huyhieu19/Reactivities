using Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace Utils;

public static class QueryableExtensions
{
    public static async Task<PagedResult<TResult>> ApplyFilterAndPaginationAsync<TEntity, TResult>(
        this IQueryable<TEntity> source,
        PaginationParameter pagination,
        Func<TEntity, TResult> convertEntityToDto = null)
    {
        // Áp dụng bộ lọc
        var filteredQuery = source.Filter(pagination.Filters, pagination.SearchKeyword, pagination.SearchColumns, pagination.Sorter);

        // Tính tổng số phần tử sau khi lọc
        var totalItems = await filteredQuery.CountAsync();

        // Áp dụng phân trang và chuyển đổi
        var pagedData = await filteredQuery
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        // Áp dụng delegate chuyển đổi nếu có
        var resultData = convertEntityToDto != null
            ? pagedData.Select(convertEntityToDto).ToList()
            : pagedData.Cast<TResult>().ToList();

        return new PagedResult<TResult>(resultData, totalItems, pagination.PageNumber, pagination.PageSize);
    }

    // Phương thức Filter tổng quát cho Entity Framework Core
    public static IQueryable<T> Filter<T>(
        this IQueryable<T> source,
        Dictionary<string, List<string>> filters,
        string searchKeyword = null,
        List<string> searchColumns = null,
        Dictionary<string, SortType> sortCriteria = null)
    {
        var parameter = Expression.Parameter(typeof(T), "entity");
        Expression finalExpression = null;

        // Apply filters based on dictionary keys and list of values for each key
        if (filters != null)
        {
            foreach (var filter in filters)
            {
                // Retrieve the property with case-insensitivity
                var property = typeof(T).GetProperty(filter.Key, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (property == null) continue;

                // Create the member expression for the property
                var member = Expression.Property(parameter, property);

                // Get a type converter for the property type
                var converter = TypeDescriptor.GetConverter(property.PropertyType);

                // Create OR expressions for each value in the list
                var valueExpressions = filter.Value.Select(value =>
                {
                    // Convert the filter value to the property type
                    object typedValue;
                    try
                    {
                        // Convert the filter value to the property type
                        typedValue = converter.ConvertFromInvariantString(value);
                    }
                    catch
                    {
                        // Skip invalid values that can't be converted
                        return Expression.Constant(false);
                    }

                    // Create an equality expression between the property and the converted value
                    return (Expression)Expression.Equal(member, Expression.Constant(typedValue, property.PropertyType));
                })
                .Aggregate((current, next) => Expression.OrElse(current, next));

                // Combine with the final expression
                finalExpression = finalExpression == null
                    ? valueExpressions
                    : Expression.AndAlso(finalExpression, valueExpressions);
            }
        }

        // Apply search keyword across specified columns
        if (!string.IsNullOrEmpty(searchKeyword) && searchColumns != null && searchColumns.Any())
        {
            var searchExpressions = searchColumns.Select(column =>
            {
                var member = Expression.Property(parameter, column);
                var likeExpression = BuildContainsExpression(member, searchKeyword);
                return (Expression)likeExpression;
            });
            var searchExpression = searchExpressions.Aggregate((current, next) => Expression.OrElse(current, next));
            finalExpression = finalExpression == null ? searchExpression : Expression.AndAlso(finalExpression, searchExpression);
        }

        // Return queryable source with applied filters
        if (finalExpression == null)
        {
            if (sortCriteria == null)
            {
                return source;
            }
            return ApplySorting(source, sortCriteria);
        }

        var lambda = Expression.Lambda<Func<T, bool>>(finalExpression, parameter);
        var filteredResult = source.Where(lambda);
        if (sortCriteria == null)
        {
            return filteredResult;
        }
        return ApplySorting(filteredResult, sortCriteria);
    }

    private static IQueryable<T> ApplySorting<T>(IQueryable<T> source, Dictionary<string, SortType> sortCriteria)
    {
        if (sortCriteria != null && sortCriteria.Any())
        {
            IOrderedQueryable<T> orderedQuery = null;
            foreach (var criterion in sortCriteria)
            {
                // Thêm bindingAttr: BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase => không phân biệt chữ hoa thữ thường
                var property = typeof(T).GetProperty(criterion.Key, bindingAttr: BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (property == null) continue;

                var parameter = Expression.Parameter(typeof(T), "x");
                var member = Expression.Property(parameter, property);
                var orderByExp = Expression.Lambda(member, parameter);

                // Directly invoke the appropriate OrderBy or OrderByDescending method
                if (orderedQuery == null)
                {
                    orderedQuery = criterion.Value == SortType.Ascending
                        ? Queryable.OrderBy(source, (dynamic)orderByExp)
                        : Queryable.OrderByDescending(source, (dynamic)orderByExp);
                }
                else
                {
                    orderedQuery = criterion.Value == SortType.Ascending
                        ? Queryable.ThenBy(orderedQuery, (dynamic)orderByExp)
                        : Queryable.ThenByDescending(orderedQuery, (dynamic)orderByExp);
                }
            }

            return orderedQuery ?? source; // return ordered result or original source if no sorting was applied
        }

        return source;
    }


    // Phương thức xây dựng biểu thức Contains cho tìm kiếm chuỗi
    private static Expression BuildContainsExpression(MemberExpression member, string searchKeyword)
    {
        Expression memberAsString;

        // Add a null check for the member
        var nullCheck = Expression.NotEqual(member, Expression.Constant(null, member.Type));

        // Check if the member's type is not a string, and convert it to string if needed
        if (member.Type != typeof(string))
        {
            var toStringMethod = member.Type.GetMethod("ToString", Type.EmptyTypes);

            memberAsString = Expression.Condition(nullCheck,
                Expression.Call(member, toStringMethod),
                Expression.Constant(string.Empty));
        }
        else
        {
            memberAsString = member;
        }

        // Call Contains on the string representation
        var containsMethod = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string) });
        var searchExpression = Expression.Call(
            memberAsString,
            containsMethod,
            Expression.Constant(searchKeyword, typeof(string))
        );

        // Null check for member
        return Expression.AndAlso(nullCheck, searchExpression);
    }
}
