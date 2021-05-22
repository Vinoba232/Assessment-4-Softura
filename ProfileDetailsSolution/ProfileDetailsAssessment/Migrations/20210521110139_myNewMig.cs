using Microsoft.EntityFrameworkCore.Migrations;

namespace ProfileDetailsAssessment.Migrations
{
    public partial class myNewMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmployed = table.Column<bool>(type: "bit", nullable: false),
                    NoticePeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentCTC = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
