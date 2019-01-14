using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD.DATA.Migrations
{
    public partial class _1401 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SBDUserId",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_SBDUserId",
                table: "Prescriptions",
                column: "SBDUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_AspNetUsers_SBDUserId",
                table: "Prescriptions",
                column: "SBDUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_AspNetUsers_SBDUserId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_SBDUserId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "SBDUserId",
                table: "Prescriptions");
        }
    }
}
