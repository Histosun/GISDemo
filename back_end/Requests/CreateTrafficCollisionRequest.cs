using FluentValidation;
using NetTopologySuite.Geometries;

namespace GISDemo.Requests;

public class CreateTrafficCollisionRequest
{
    public string Location { get; set; }
    public int GeoId { get; set; }
    public int TotalCollisions { get; set; }
    public int F2015Total { get; set; }
    public int F2016Total { get; set; }
    public int F2017Total { get; set; }
    public int F2018Total { get; set; }
    public int F2019Total { get; set; }
    public int ObjectId { get; set; }
    public Point Geometry { get; set; }
}

public class CreateTrafficCollisionRequestValidator : AbstractValidator<CreateTrafficCollisionRequest>
{
    public CreateTrafficCollisionRequestValidator()
    {
        RuleFor(x => x.Location).NotEmpty();
        RuleFor(x => x.Geometry).NotNull();
    }
}