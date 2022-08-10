using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockProject.API.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "tAdminUsers");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "tPermissions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "tPermissions");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "tAdminUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
