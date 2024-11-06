using Domain;
using System.Linq.Expressions;

namespace Persistence.Repository.Interface
{
    public interface IBaseRepository
    {
        public interface IBaseRepository<TFactDbContext> where TFactDbContext : DataContext
        {
            #region Create
            Task<T> AddAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class;
            Task<int> AddRangeAsync<T>(IEnumerable<T> entities, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class;
            #endregion

            #region Update
            Task<T> UpdateAsync<T>(T Entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class;
            Task<int> UpdateRangeAsync<T>(IEnumerable<T> entities, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class;
            #endregion

            #region Delete (use)

            Task<int> DeleteAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class;
            Task<int> DeleteAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;

            #endregion Delete (use)

            #region Delete (admin use only)

            Task<int> DeleteForAdminAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class;

            Task<int> DeleteRangeForAdminAsync<T>(IEnumerable<T> entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class;

            #endregion Delete (admin use only)

            #region Retrive

            Task<List<T>> GetAsync<T>(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class;

            Task<List<R>> GetAsync<T, R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class;

            Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class;

            #endregion Retrive

            #region Query

            IQueryable<T> Query<T>(Expression<Func<T, bool>> predicate = null) where T : class;

            IQueryable<T> QueryAsTracking<T>(Expression<Func<T, bool>> predicate = null) where T : class;

            #endregion Query

            #region Find

            Task<T> FindFirstAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class;
            Task<T> FindFirstForUpdateAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class;

            #endregion

            #region Transaction

            Task ActionInTransaction(Func<Task> action);

            #endregion Transaction

            Task<int> SaveChangeAsync(bool clearTracker = false, CancellationToken cancellationToken = default);


            #region Pagination
            Task<PagedResult<R>> GetPagination<T, R>(PaginationParameter pagination, Func<T, R> converter, CancellationToken cancellationToken = default) where T : class;
            Task<PagedResult<R>> GetPagination<T, R>(PaginationParameter pagination, IQueryable<T> queryable, Func<T, R> converter = null, CancellationToken cancellationToken = default) where T : class;
            #endregion
        }
    }
}
