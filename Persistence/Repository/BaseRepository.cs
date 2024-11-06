using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using Utils;
using static Persistence.Repository.Interface.IBaseRepository;

namespace Persistence.Repository;

public sealed class BaseRepository<TDbContext> : IBaseRepository<TDbContext> where TDbContext : DataContext
{
    private readonly TDbContext _dbContext;
    private readonly ILogger<BaseRepository<TDbContext>> _logger;
    public BaseRepository(TDbContext dbcontext, ILogger<BaseRepository<TDbContext>> logger)
    {
        _logger = logger;
        _dbContext = dbcontext;
    }

    #region Create
    public async Task<T> AddAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class
    {
        var entry = await _dbContext.AddAsync(entity, cancellationToken);
        await SaveChangeAsync(clearTracker, cancellationToken);
        return entry.Entity;
    }

    public async Task<int> AddRangeAsync<T>(IEnumerable<T> entities, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class
    {
        await _dbContext.AddRangeAsync(entities, cancellationToken);
        var result = await SaveChangeAsync(clearTracker, cancellationToken);
        return result;
    }
    #endregion

    #region Update
    public async Task<T> UpdateAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class
    {
        var result = _dbContext.Set<T>().Update(entity);
        await SaveChangeAsync(clearTracker, cancellationToken);
        return result.Entity;
    }

    public async Task<int> UpdateRangeAsync<T>(IEnumerable<T> entities, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class
    {
        foreach (var entity in entities)
        {
            _dbContext.Set<T>().Update(entity);
        }
        var result = await SaveChangeAsync(clearTracker, cancellationToken);
        return result;
    }
    #endregion Update

    #region Delete (use)
    public async Task<int> DeleteAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
    {
        var entity = await _dbContext.Set<T>().AsTracking().FirstOrDefaultAsync(predicate, cancellationToken) ?? throw new Exception("can not found");
        if (entity is BaseIdEntity<Guid> deletableEntity)
        {
            deletableEntity.IsDeleted = true;
            deletableEntity.TimeDeleted = DateTimeOffset.Now;
            _dbContext.Set<T>().Update(entity);
        }
        else
        {
            _dbContext.Set<T>().Remove(entity);
        }
        return await SaveChangeAsync();
    }
    public async Task<int> DeleteAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
    {
        if (entity is BaseIdEntity<Guid> deletableEntity)
        {
            deletableEntity.IsDeleted = true;
            deletableEntity.TimeDeleted = DateTimeOffset.Now;
            _dbContext.Set<T>().Update(entity);
        }
        else
        {
            _dbContext.Set<T>().Remove(entity);
        }
        var result = await SaveChangeAsync(false, cancellationToken);
        return result;
    }
    #endregion Delete (use)

    #region Delete (admin use only)

    public async Task<int> DeleteForAdminAsync<T>(T entity, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class
    {
        _dbContext.Set<T>().Remove(entity);
        var result = await SaveChangeAsync(clearTracker, cancellationToken);
        return result;
    }

    public async Task<int> DeleteRangeForAdminAsync<T>(IEnumerable<T> entities, bool clearTracker = false, CancellationToken cancellationToken = default) where T : class
    {
        _dbContext.Set<T>().RemoveRange(entities);
        var result = await SaveChangeAsync(clearTracker, cancellationToken);
        return result;
    }
    #endregion Delete (admin use only)

    #region Retrive
    public async Task<List<T>> GetAsync<T>(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class
    {
        if (predicate == null)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }
        return await _dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<List<R>> GetAsync<T, R>(Expression<Func<T, R>> selector, Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class
    {
        if (predicate == null)
        {
            return await _dbContext.Set<T>().Select(selector).ToListAsync(cancellationToken);
        }
        return await _dbContext.Set<T>().Where(predicate).Select(selector).ToListAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate = null, CancellationToken cancellationToken = default) where T : class
    {
        return await _dbContext.Set<T>().AnyAsync(predicate, cancellationToken);
    }
    // get with paging

    #endregion Retrive
    #region Query
    public IQueryable<T> Query<T>(Expression<Func<T, bool>> predicate = null) where T : class
    {
        if (predicate == null)
        {
            return _dbContext.Set<T>();
        }
        return _dbContext.Set<T>().Where(predicate);
    }

    public IQueryable<T> QueryAsTracking<T>(Expression<Func<T, bool>> predicate = null) where T : class
    {
        if (predicate == null)
        {
            return _dbContext.Set<T>().AsTracking();
        }
        return _dbContext.Set<T>().Where(predicate).AsTracking();
    }
    #endregion Query

    #region Find
    public async Task<T> FindFirstAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
    {
        if (predicate == null)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }
        return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken);
    }
    public async Task<T> FindFirstForUpdateAsync<T>(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) where T : class
    {
        if (predicate == null)
        {
            return await _dbContext.Set<T>().AsTracking().FirstOrDefaultAsync(cancellationToken);
        }
        return await _dbContext.Set<T>().AsTracking().FirstOrDefaultAsync(predicate, cancellationToken);
    }
    #endregion

    #region Transaction
    public async Task ActionInTransaction(Func<Task> action)
    {
        using (var transaction = _dbContext.Database.BeginTransaction())
        {
            try
            {
                // Perform multiple database operations within the transaction
                await action();
                // Commit the transaction
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Transaction failed");
                // Rollback the transaction if any operation fails
                transaction.Rollback();
            }
        }
    }
    #endregion Transaction

    #region Clear tracker

    public async Task<int> SaveChangeAsync(bool clearTracker = false, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.SaveChangesAsync(cancellationToken);
        if (clearTracker)
        {
            _dbContext.ChangeTracker.Clear();
        }
        return result;
    }


    #endregion Clear tracker

    #region Pagination
    public Task<PagedResult<R>> GetPagination<T, R>(PaginationParameter pagination, Func<T, R> converter = null, CancellationToken cancellationToken = default) where T : class
    {
        return _dbContext.Set<T>().ApplyFilterAndPaginationAsync(pagination, converter);
    }
    public Task<PagedResult<R>> GetPagination<T, R>(PaginationParameter pagination, IQueryable<T> queryable, Func<T, R> converter = null, CancellationToken cancellationToken = default) where T : class
    {
        return queryable.ApplyFilterAndPaginationAsync(pagination, converter);
    }
    #endregion
}
