using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockProject.API.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tJobOrders_tAdminUsers_StaffId",
                table: "tJobOrders");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "tJobOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tJobOrders_tAdminUsers_StaffId",
                table: "tJobOrders",
                column: "StaffId",
                principalTable: "tAdminUsers",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tJobOrders_tAdminUsers_StaffId",
                table: "tJobOrders");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "tJobOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tJobOrders_tAdminUsers_StaffId",
                table: "tJobOrders",
                column: "StaffId",
                principalTable: "tAdminUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
