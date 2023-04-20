using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace back_end.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "traffic_collision",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    location = table.Column<string>(type: "text", nullable: false),
                    geo_id = table.Column<int>(type: "integer", nullable: false),
                    total_collisions = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    F2015Total = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    F2016Total = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    F2017Total = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    F2018Total = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    F2019Total = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Geometry = table.Column<Point>(type: "GEOMETRY(Point, 4326) ", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_traffic_collision", x => x.id);
                },
                comment: "article table");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "traffic_collision");
        }
    }
}
