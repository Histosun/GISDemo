using GISDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace GISDemo.Repositories;

public class TrafficCollisionRepository
{
    private readonly DbSet<TrafficCollisionEntity> TrafficCollisions;

    public TrafficCollisionRepository(GISDbContext gisDbContext)
    {
        TrafficCollisions = gisDbContext.TrafficCollisions;
    }

    public TrafficCollisionEntity? GetById(int id)
    {
        return TrafficCollisions.Find(id);
    }

    public TrafficCollisionEntity[] GetAll()
    {
        return TrafficCollisions.ToArray();
    }

    public void AddCollisions(TrafficCollisionEntity[] collisions)
    {
        TrafficCollisions.AddRange(collisions);
    }
}