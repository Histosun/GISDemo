using GISDemo.Entities;
using GISDemo.Repositories;
using GISDemo.Requests;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Features;

namespace GISDemo.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TrafficCollisionsController : ControllerBase
{
    private readonly TrafficCollisionRepository TrafficCollisionRepository;

    public TrafficCollisionsController(TrafficCollisionRepository repository) {
        TrafficCollisionRepository = repository;
    }

    [HttpPost]
    public void CreateTrafficCollisions(FeatureCollection features)
    {
        var entities = features.Select(TrafficCollisionEntity.Create).ToArray();
        TrafficCollisionRepository.AddCollisions(entities);
    }

    [HttpPost]
    public void CreateTrafficCollisions1(TestRequest request)
    {
        
    }
}
