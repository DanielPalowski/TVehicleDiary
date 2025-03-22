using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDiary.Migrations
{
    /// <inheritdoc />
    public partial class RepairingTotalCostFromRepairToVehicleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepairTotalCost",
                table: "DBRepairsSet");

            migrationBuilder.AddColumn<int>(
                name: "RepairCost",
                table: "DBVehiclesSet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepairCost",
                table: "DBVehiclesSet");

            migrationBuilder.AddColumn<int>(
                name: "RepairTotalCost",
                table: "DBRepairsSet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
