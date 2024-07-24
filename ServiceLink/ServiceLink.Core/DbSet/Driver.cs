using System;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace ServiceLink.Core.DbSet;

public class Driver : BaseEntity
{
    public Driver()
    {
        Achievements = new HashSet<Achievement>();
    }

    public string? username { get; set;}
    public string? LastName { get; set; }
    public int DriverNumber { get; set; }
    public DateTime DataOfBirth { get; set; }



    // One - To - Many Relations ship ( Driver with Achievements )
    public virtual ICollection<Achievement> Achievements { get; set; }

}
    



