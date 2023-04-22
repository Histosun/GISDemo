using NetTopologySuite.Features;
using NetTopologySuite.Geometries;

namespace GISDemo.Entities;

public class TrafficCollisionEntity
{
    public int Id { get; set; }
    public string Location { get; set; }
    public int TotalCollisions { get; set; }
    public int F2015Total { get; set; }
    public int F2016Total { get; set; }
    public int F2017Total { get; set; }
    public int F2018Total { get; set; }
    public int F2019Total { get; set; }
    public Point Geometry { get; set; }

    public static TrafficCollisionEntity Create(IFeature feature)
    {
        TrafficCollisionEntity collision = new();
        collision.TotalCollisions = Decimal.ToInt32((Decimal)feature.Attributes.GetOptionalValue("Total_Collisions"));
        collision.F2015Total = Decimal.ToInt32((Decimal)feature.Attributes.GetOptionalValue("F2015_Total"));
        collision.F2016Total = Decimal.ToInt32((Decimal)feature.Attributes.GetOptionalValue("F2016_Total"));
        collision.F2017Total = Decimal.ToInt32((Decimal)feature.Attributes.GetOptionalValue("F2017_Total"));
        collision.F2018Total = Decimal.ToInt32((Decimal)feature.Attributes.GetOptionalValue("F2018_Total"));
        collision.F2019Total = Decimal.ToInt32((Decimal)feature.Attributes.GetOptionalValue("F2019_Total"));
        collision.Location = (string)feature.Attributes.GetOptionalValue("Location");
        collision.Geometry = (Point)feature.Geometry;
        return collision;
    }

    public IFeature ToFeature(){
        var attributes = new AttributesTable();
        attributes.Add("id", Id);
        attributes.Add("total", TotalCollisions);
        attributes.Add("Location", Location);
        return new Feature(Geometry, attributes);
    }
}