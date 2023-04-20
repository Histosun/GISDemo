
using GISDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GISDemo.Configs;
public class TrafficCollisionConfig : IEntityTypeConfiguration<TrafficCollisionEntity>
{
    public void Configure(EntityTypeBuilder<TrafficCollisionEntity> builder)
    {
        builder.ToTable("traffic_collision");

        builder.HasComment("article table");

        builder.Property(e => e.Id)
            .HasColumnName("id");

        builder.Property(e => e.Location)
            .HasColumnName("location")
            .IsRequired();

        builder.Property(e => e.GeoId)
            .HasColumnName("geo_id");

        builder.Property(e => e.TotalCollisions)
            .HasColumnName("total_collisions")
            .HasDefaultValue<int>(0);

        builder.Property(e => e.F2015Total)
            .HasDefaultValue<int>(0);

        builder.Property(e => e.F2016Total)
            .HasDefaultValue<int>(0);

        builder.Property(e => e.F2017Total)
            .HasDefaultValue<int>(0);

        builder.Property(e => e.F2018Total)
            .HasDefaultValue<int>(0);

        builder.Property(e => e.F2019Total)
            .HasDefaultValue<int>(0);

        builder.Property(e => e.Geometry)
            .HasColumnType("GEOMETRY(Point, 4326) ")
            .IsRequired();
    }
}
