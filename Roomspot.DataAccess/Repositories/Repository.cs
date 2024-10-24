using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Roomspot.DataAccess.Context;

namespace Roomspot.DataAccess.Repositories;
public interface IRepository<T> where T : class
{
    DbSet<T> Entities { get; }
    DbContext DbContext { get; }
    #region Sync

    public IQueryable<T> Get();
    public IQueryable<T?> Where(Expression<Func<T, bool>> predic = null);
    public void Add(T entity);
    public void Update(T entity);
    public int Count();
    public T FirstOrDefault();
    public T LastOrDefault();
    public int SaveChanges();
    public T FirstOrDefault(Expression<Func<T, bool>> predicate);
    public T? Find(params object?[]? keyValues); 

    #endregion
    
    #region Async

    /// <summary>
    /// unsafe to use, ill
    /// </summary>
    /// <returns>Task<IQueryable<T>></returns>
    public Task<IQueryable<T>> GetAsync();
    public Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> predic = null);
    public Task AddAsync(T entity, bool saveChanges = true);
    public Task AddRangeAsync(List<T> entities, bool saveChanges = true);
    public Task UpdateAsync(T entity, bool saveChanges = true);
    public Task RemoveAsync(T entity, bool saveChanges = true);
    public Task<T?> FirstOrDefaultAsync();
    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    public Task<T?> FindAsync(params object?[]? keyValues);
    public Task<int> SaveAsync();

    #endregion
   
}
public class Repository<T> : IRepository<T> where T : class
{
    public DbContext DbContext { get; private set; }
    public DbSet<T> Entities => DbContext.Set<T>();
    
    public Repository(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    public IQueryable<T> Get()
    {
        return Entities.AsQueryable();
    }

    public IQueryable<T?> Where(Expression<Func<T, bool>> predic = null)
    {
        return Entities.Where<T>(predic).AsQueryable();
    }

    public void Add(T entity)
    {
        Entities.Add(entity);
    }

    public T? Find(Expression<Func<T, bool>> expression)
    {
        return Entities.Find(expression);
    }

    public T? Find(params object?[]? keyValues)
    {
        return Entities.Find(keyValues);
    }

    public async Task<IQueryable<T>> GetAsync()
    {
        return await (Task<IQueryable<T>>) Entities.AsQueryable();
    }

    public async Task<IQueryable<T>> WhereAsync(Expression<Func<T, bool>> predic = null)
    {
        return await (Task<IQueryable<T>>) Entities.Where<T>(predic).AsQueryable();
    }

    public async Task AddAsync(T entity, bool saveChanges = true)
    {
        await Entities.AddAsync(entity);
        if (saveChanges)
        {
            await DbContext.SaveChangesAsync();
        }
    }

    public async Task AddRangeAsync(List<T> entities, bool saveChanges = true)
    {
        await Entities.AddRangeAsync(entities);
        if (saveChanges)
        {
            await DbContext.SaveChangesAsync();
        }
    }

    public void Update(T entity)
    {
        Entities.Update(entity);
    }

    public async Task UpdateAsync(T entity, bool saveChanges = true)
    {
        Entities.Update(entity);
        if (saveChanges)
        {
            await DbContext.SaveChangesAsync();
        }
    }

    public async Task RemoveAsync(T entity, bool saveChanges = true)
    {
        Entities.Remove(entity);
        if (saveChanges)
        {
            await DbContext.SaveChangesAsync();
        }
    }

    public int Count()
    {
        return Entities.Count();
    }

    public T? FirstOrDefault()
    {
        return Entities.FirstOrDefault();
    }

    public T? LastOrDefault()
    {
        return Entities.LastOrDefault();
    }

    public T? FirstOrDefault(Expression<Func<T, bool>> predicate)
    {
        return Entities.FirstOrDefault(predicate);
    }

    public async Task<T?> FirstOrDefaultAsync()
    {
        return await Entities.FirstOrDefaultAsync();
    }

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await Entities.FirstOrDefaultAsync(predicate);
    }

    public int SaveChanges()
    {
        return DbContext.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await DbContext.SaveChangesAsync();
    }

    public async Task<T?> FindAsync(params object?[]? keyValues)
    {
        return await Entities.FindAsync(keyValues);
    }
}