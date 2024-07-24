using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceLink.Core.DbSet;
using ServiceLink.EF.Data;
using ServiceLink.EF.Interfaces;

namespace ServiceLink.EF.Reposatory;

public class AchivementRepository : GenericRepository<Achievement>, IAchivementReposatory
{

    public AchivementRepository(AppDbContext appDbContext , ILogger logger) : base(appDbContext,logger )
    {
        
    }

    public async Task<Achievement> GetDriverAchievementsAsync(Guid driverID)
    {
        try
        {
            var achivement = await _dbSet.FirstOrDefaultAsync(x => x.Id == driverID);
            return achivement;
        }
        catch (System.Exception e)
        {
            _logger.LogError(e,"There is a problem with GetDriveAcivementAsync " , typeof(AchivementRepository));
            throw;
        }
    }

    public override async Task<IEnumerable<Achievement>> All()
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

    public override async Task<bool> Update(Achievement Achive) {
        
        try
        {
            var result1 = await _dbSet.FindAsync(Achive);

            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == Achive.Id);
            
            if(result == null) return false;


            Achive.FastestLab = Achive.FastestLab;
            Achive.PolePosition = Achive.PolePosition;
            Achive.RaceWins = Achive.RaceWins;
            Achive.status = Achive.status;

            return true;
        }
        catch (System.Exception e)
        {
            _logger.LogError(e,"There is error with Update function" , typeof(AchivementRepository));
            throw;
        }

    }


}
