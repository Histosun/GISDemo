using NetTopologySuite.Geometries;

namespace GISDemo.Entities;

public class TrafficCollisionEntity
{
    public int Id { get; set; }
    public string Location { get; set; }
    public int GeoId { get; set; }
    public int TotalCollisions { get; set; }
    public int F2015Total { get; set; }
    public int F2016Total { get; set; }
    public int F2017Total { get; set; }
    public int F2018Total { get; set; }
    public int F2019Total { get; set; }
    public Point Geometry { get; set; }
}