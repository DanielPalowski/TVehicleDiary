using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDiary.Migrations
{
    /// <inheritdoc />
    public partial class DBRepairUpdatingIDtoINT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DBRepairsSet_AspNetUsers_VehicleId",
                table: "DBRepairsSet");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "DBRepairsSet",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_DBRepairsSet_DBVehiclesSet_VehicleId",
                table: "DBRepairsSet",
                column: "VehicleId",
                principalTable: "DBVehiclesSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DBRepairsSet_DBVehiclesSet_VehicleId",
                table: "DBRepairsSet");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleId",
                table: "DBRepairsSet",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DBRepairsSet_AspNetUsers_VehicleId",
                table: "DBRepairsSet",
                column: "VehicleId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
