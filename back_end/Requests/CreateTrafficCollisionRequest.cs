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
    public int TotalCyclistsCollisions { get; set; }
    public int F2015Cyclists { get; set; }
    public int F2016Cyclists { get; set; }
    public int F2017Cyclists { get; set; }
    public int F2018Cyclists { get; set; }
    public int F2019Cyclists { get; set; }
    public int TotalPedestrians { get; set; }
    public int F2015Pedestrians { get; set; }
    public int F2016Pedestrians { get; set; }
    public int F2017Pedestrians { get; set; }
    public int F2018Pedestrians { get; set; }
    public int F2019Pedestrians { get; set; }
    public int ObjectId { get; set; }
    public Point Geometry { get; set; }
}