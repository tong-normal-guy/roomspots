using Microsoft.EntityFrameworkCore;
using Roomspot.DataAccess.Context;

namespace Roomspot.DataAccess.Repositories;

public class DbFactory : IDisposable
{
    private bool _disposed;
    private Func<MyDbContext> _instanceFunc;
    private DbContext _dbContext;
    public DbContext DbContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke());
 
    public DbFactory(Func<MyDbContext> dbContextFactory)
    {
        _instanceFunc = dbContextFactory;
    }
 
    public void Dispose()
    {
        if (!_disposed && _dbContext != null)
        {
            _disposed = true;
            _dbContext.Dispose();
        }
    }
}