using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplicantMicroserviceAPI.Migrations
{
    public partial class ResumeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resume",
                table: "JobApplicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resume",
                table: "JobApplicants");
        }
    }
}
