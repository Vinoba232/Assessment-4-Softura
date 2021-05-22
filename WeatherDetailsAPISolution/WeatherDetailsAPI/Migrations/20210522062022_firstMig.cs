using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherDetailsAPI.Migrations
{
    public partial class firstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    City = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HighTemp = table.Column<float>(type: "real", nullable: false),
                    LowTemp = table.Column<float>(type: "real", nullable: false),
                    Forcast = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.City);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");
        }
    }
}
