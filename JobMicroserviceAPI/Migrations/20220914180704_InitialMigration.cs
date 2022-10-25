using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobMicroserviceAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanySize = table.Column<int>(type: "int", nullable: true),
                    JobLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Openings = table.Column<int>(type: "int", nullable: false),
                    MinPackage = table.Column<double>(type: "float", nullable: true),
                    MaxPackage = table.Column<double>(type: "float", nullable: true),
                    MinExp = table.Column<int>(type: "int", nullable: false),
                    Perk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobPostDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountOfApplicants = table.Column<int>(type: "int", nullable: true),
                    OpenApplicationCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
