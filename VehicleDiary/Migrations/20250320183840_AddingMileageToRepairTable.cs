using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDiary.Migrations
{
    /// <inheritdoc />
    public partial class AddingMileageToRepairTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepairMileage",
                table: "DBRepairsSet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepairMileage",
                table: "DBRepairsSet");
        }
    }
}
