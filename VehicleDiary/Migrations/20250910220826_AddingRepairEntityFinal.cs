using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDiary.Migrations
{
    /// <inheritdoc />
    public partial class AddingRepairEntityFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBRepairVehicleModelsSet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepairVCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RepairVType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RepairVName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairVPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairVWhen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepairVPrice = table.Column<float>(type: "real", nullable: false),
                    ReapairVNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairVTechnician = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBRepairVehicleModelsSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DBRepairVehicleModelsSet_DBVehiclesSet_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "DBVehiclesSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DBRepairVehicleModelsSet_VehicleId",
                table: "DBRepairVehicleModelsSet",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBRepairVehicleModelsSet");
        }
    }
}
