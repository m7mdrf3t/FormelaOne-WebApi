using Microsoft.EntityFrameworkCore;
using ServiceLink.Core.DbSet;

namespace ServiceLink.EF.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public virtual DbSet<Achievement> Achievements { get; set; }
    public virtual DbSet<Driver> Drivers {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Achievement>( entity => 
        {
            entity.HasOne(d => d.Driver).
                    WithMany(s => s.Achievements). 
                    HasForeignKey(f => f.DriverID).
                    OnDelete(DeleteBehavior.NoAction).
                    HasConstraintName("FK_Achievement_Drive");
        });

    }
    
}
