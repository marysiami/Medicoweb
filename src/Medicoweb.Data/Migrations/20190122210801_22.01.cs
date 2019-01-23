using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medicoweb.Data.Migrations
{
    public partial class _2201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitsTimes");

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Visits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Visits",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Visits");

            migrationBuilder.CreateTable(
                name: "VisitsTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    VisitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitsTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitsTimes_Visits_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Visits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VisitsTimes_VisitId",
                table: "VisitsTimes",
                column: "VisitId",
                unique: true);
        }
    }
}
