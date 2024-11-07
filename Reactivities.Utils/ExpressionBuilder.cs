using System.Linq.Expressions;

namespace Reactivities.Utils;

public static class ExpressionBuilder
{
    public static Expression<Func<T, bool>> True<T>() => x => true;

    public static Expression<Func<T, bool>> False<T>() => x => false;

    // Phương thức AND
    public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        // Thay thế tham số của expr2 bằng tham số của expr1
        var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
        var body = Expression.AndAlso(expr1.Body, invokedExpr);

        return Expression.Lambda<Func<T, bool>>(body, expr1.Parameters);
    }

    // Phương thức OR
    public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
    {
        // Thay thế tham số của expr2 bằng tham số của expr1
        var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
        var body = Expression.OrElse(expr1.Body, invokedExpr);

        return Expression.Lambda<Func<T, bool>>(body, expr1.Parameters);
    }
}