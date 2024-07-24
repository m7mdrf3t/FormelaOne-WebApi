using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceLink.Core.DbSet;
using ServiceLink.EF.Data;
using ServiceLink.EF.Interfaces;

namespace ServiceLink.EF.Reposatory;

public class DriverRepository : GenericRepository<Driver>, IDriverReposatory
{

    public DriverRepository(AppDbContext context , ILogger logger) : base(context , logger)
    {
        
    }
    

    public override async Task<IEnumerable<Driver>> All()
    {
        try
        {
            var result = await _dbSet.Where(a => a.status == 1)
                                    .AsNoTracking()
                                    .AsSplitQuery()
                                    .OrderBy(x => x.AddTime)
                                    .ToListAsync();

            return result;                        

        }
        catch (System.Exception e)
        {
            _logger.LogError(e,"There was an error in All Function " , typeof(DriverRepository));
            throw;
        }
    }


    public override async Task<bool> Delete(Guid id)
    {

        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(a => a.Id == id);

            if(result == null) return false;

            result.status = 0;
            result.UpdateTime = DateTime.UtcNow;
            return true;                        

        }
        catch (System.Exception e)
        {
            _logger.LogError(e,"There was an error in Delete Function " , typeof(DriverRepository));
            throw;
        }
    }


    public override async Task<bool> Update(Driver driver) {
        
        try
        {
            var result1 = await _dbSet.FindAsync(driver);

            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == driver.Id);
            
            if(result == null) return false;

            result.Achievements = driver.Achievements;
            result.AddTime = DateTime.UtcNow;
            result.DataOfBirth = driver.DataOfBirth;
            result.DriverNumber = driver.DriverNumber;
            result.username = driver.username;
            result.LastName = driver.LastName;
            

            return true;
        }
        catch (System.Exception)
        {
            
            throw;
        }

    }

}
