using GISDemo.Entities;
using GISDemo.Repositories;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Features;

namespace GISDemo.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TrafficCollisionsController : ControllerBase
{
    private readonly TrafficCollisionRepository TrafficCollisionRepository;
    private readonly GISDbContext DbContext;

    public TrafficCollisionsController(TrafficCollisionRepository repository, GISDbContext context) {
        TrafficCollisionRepository = repository;
        DbContext = context;
    }

    [HttpPost]
    public void CreateTrafficCollisions(FeatureCollection features)
    {
        var entities = features.Select(TrafficCollisionEntity.Create).ToArray();
        DbContext.AddRange(entities);
        DbContext.SaveChanges();
    }

    [HttpGet]
    public IEnumerable<IFeature> GetTrafficCollisions()
    {
        return TrafficCollisionRepository.GetAll().Select(it => it.ToFeature());
    }
}