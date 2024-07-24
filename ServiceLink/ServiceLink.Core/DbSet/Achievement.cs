using System.Text.Json.Serialization;

namespace ServiceLink.Core.DbSet;

public class Achievement : BaseEntity
{
    public int RaceWins { get; set; }
    public int PolePosition { get; set; }
    public int FastestLab { get; set; }
    public int WorldChampionship { get; set; }
    public Guid DriverID { get; set; }
    public Driver? Driver {get; set;}   
}


