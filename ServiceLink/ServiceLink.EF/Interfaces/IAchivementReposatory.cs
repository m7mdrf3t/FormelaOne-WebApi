using ServiceLink.Core.DbSet;

namespace ServiceLink.EF.Interfaces;

public interface IAchivementReposatory : IGenereicReposatory<Achievement>
{
    Task<Achievement> GetDriverAchievementsAsync(Guid driverID);
}