using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDiary.Migrations
{
    /// <inheritdoc />
    public partial class DBRepairsSetAddingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBRepairsSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairCost = table.Column<int>(type: "int", nullable: false),
                    RepairMade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBRepairsSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBRepairsSet_AspNetUsers_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DBRepairsSet_VehicleId",
                table: "DBRepairsSet",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBRepairsSet");
        }
    }
}
