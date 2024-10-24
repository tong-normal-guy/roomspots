using System.Data;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using IsolationLevel = System.Data.IsolationLevel;

namespace Roomspot.DataAccess.Repositories;

public interface IUnitOfWork
{
    DbContext DbContext { get; }
    IRepository<T> Repository<T>() where T : class;
    void SaveChanges();
    int SaveManualChanges();
    Task SaveChangesAsync();
    Task<int> SaveManualChangesAsync();
    
    Task BeginTransaction();
    Task CommitTransaction();
    Task RollbackTransaction();
    
}
public class UnitOfWork : IUnitOfWork
{
    public DbContext DbContext { get; private set; }
    private Dictionary<string, object> Repositories { get; }
    private IDbContextTransaction _transaction;
    private IsolationLevel? _isolationLevel;

    public UnitOfWork(DbFactory dbFactory)
    {
        DbContext = dbFactory.DbContext;
        Repositories = new Dictionary<string, object>();
    }

    public IRepository<T> Repository<T>() where T : class
    {
        var type = typeof(T);
        var typeName = type.Name;

        lock (Repositories)
        {
            if (Repositories.ContainsKey(typeName))
            {
                return (IRepository<T>)Repositories[typeName];
            }

            var repository = new Repository<T>(DbContext);

            Repositories.Add(typeName, repository);
            return repository;
        }
    }

    public void SaveChanges()
    { 
        DbContext.SaveChangesAsync();
    }

    public int SaveManualChanges()
    {
        return DbContext.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await DbContext.SaveChangesAsync();
    }

    public async Task<int> SaveManualChangesAsync()
    {
        return await DbContext.SaveChangesAsync();
    }

    public async Task BeginTransaction()
    {
        await StartNewTransactionIfNeeded();
    }

    public async Task CommitTransaction()
    {
        await DbContext.SaveChangesAsync();
 
        if (_transaction == null) return;
        await _transaction.CommitAsync();
 
        await _transaction.DisposeAsync();
        _transaction = null;
    }

    public async Task RollbackTransaction()
    {
        if (_transaction == null) return;
 
        await _transaction.RollbackAsync();
 
        await _transaction.DisposeAsync();
        _transaction = null;
    }
    private async Task StartNewTransactionIfNeeded()
    {
        if (_transaction == null)
        {
            _transaction =  _isolationLevel.HasValue ?
                await DbContext.Database.BeginTransactionAsync(_isolationLevel.GetValueOrDefault()) : await DbContext.Database.BeginTransactionAsync();
        }
    }
}