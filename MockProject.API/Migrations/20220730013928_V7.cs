using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockProject.API.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tNotifications_AspNetUsers_SendTo",
                table: "tNotifications");

            migrationBuilder.DropIndex(
                name: "IX_tNotifications_SendTo",
                table: "tNotifications");

            migrationBuilder.AlterColumn<string>(
                name: "SendTo",
                table: "tNotifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SendTo",
                table: "tNotifications",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_tNotifications_SendTo",
                table: "tNotifications",
                column: "SendTo");

            migrationBuilder.AddForeignKey(
                name: "FK_tNotifications_AspNetUsers_SendTo",
                table: "tNotifications",
                column: "SendTo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
