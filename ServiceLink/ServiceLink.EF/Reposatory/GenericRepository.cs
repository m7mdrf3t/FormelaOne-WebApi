using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceLink.EF.Data;
using ServiceLink.EF.Interfaces;

namespace ServiceLink.EF.Reposatory;

public class GenericRepository<T> : IGenereicReposatory<T> where T : class
{
    private readonly AppDbContext _appDbContext;
    protected readonly ILogger _logger;

    internal DbSet<T> _dbSet;

    public GenericRepository(AppDbContext appDbContext , ILogger logger)
    {
        _appDbContext = appDbContext;
        _logger = logger;

        _dbSet = appDbContext.Set<T>();
    }

    public virtual async Task<bool> Add(T entity)
    {
         await _dbSet.AddAsync(entity);
         return true;
    }

    public virtual async Task<IEnumerable<T>> All()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T?> GetbyID(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
