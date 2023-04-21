using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    public partial class RemoveGeoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "geo_id",
                table: "traffic_collision");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "geo_id",
                table: "traffic_collision",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
