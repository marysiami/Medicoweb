using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBD.DATA.Migrations
{
    public partial class _1701 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsPrescriptionNeeded",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "PatientId",
                table: "Prescriptions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_AspNetUsers_PatientId",
                table: "Prescriptions",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_AspNetUsers_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Prescriptions");

            migrationBuilder.AddColumn<Guid>(
                name: "SBDUserId",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrescriptionNeeded",
                table: "Drugs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

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
    }
}
