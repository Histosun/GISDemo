using Microsoft.EntityFrameworkCore;
using NetTopologySuite;

namespace GISDemo.Entities;

public class GISDbContext : DbContext
{

    public DbSet<TrafficCollisionEntity> TrafficCollisions { get; set; }

    public GISDbContext(DbContextOptions<GISDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
            .ApplyConfigurationsFromAssembly(GetType().Assembly);
        var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory();
    }

}