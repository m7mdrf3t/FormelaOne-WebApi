using Microsoft.Extensions.Logging;
using ServiceLink.EF.Data;
using ServiceLink.EF.Interfaces;

namespace ServiceLink.EF.Reposatory;

public class UnitOfWork : IUnitOfWork , IDisposable
{
    private readonly AppDbContext _dbContext;

    public IAchivementReposatory Achievement {get;}

    public IDriverReposatory Driver {get;}

    public UnitOfWork(AppDbContext DbContext, ILoggerFactory logger)
    {
        _dbContext = DbContext;
        var Logger = logger.CreateLogger("logs");

        Achievement = new AchivementRepository(_dbContext , Logger);
        Driver = new DriverRepository(_dbContext,Logger);

    }

    public async Task<bool> CompletedAsync()
    {
        var result = await _dbContext.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }

}
