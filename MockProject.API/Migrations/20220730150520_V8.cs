using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockProject.API.Migrations
{
    public partial class V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tNotifications_tAdminUsers_CreateBy",
                table: "tNotifications");

            migrationBuilder.DropIndex(
                name: "IX_tNotifications_CreateBy",
                table: "tNotifications");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "tNotifications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "tNotifications");

            migrationBuilder.CreateIndex(
                name: "IX_tNotifications_CreateBy",
                table: "tNotifications",
                column: "CreateBy");

            migrationBuilder.AddForeignKey(
                name: "FK_tNotifications_tAdminUsers_CreateBy",
                table: "tNotifications",
                column: "CreateBy",
                principalTable: "tAdminUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
