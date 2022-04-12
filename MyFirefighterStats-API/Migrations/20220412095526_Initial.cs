using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirefighterStats.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaySlips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaySlips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaySlipLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaySlipId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UnitAmount = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaySlipLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaySlipLine_PaySlips_PaySlipId",
                        column: x => x.PaySlipId,
                        principalTable: "PaySlips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaySlipLine_PaySlipId",
                table: "PaySlipLine",
                column: "PaySlipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaySlipLine");

            migrationBuilder.DropTable(
                name: "PaySlips");
        }
    }
}
