using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDiary.Migrations
{
    /// <inheritdoc />
    public partial class AddingDbSetToDBPetrol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBPetrolSet",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetrolDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetrolType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetrolMileage = table.Column<int>(type: "int", nullable: true),
                    PetrolPrice = table.Column<int>(type: "int", nullable: false),
                    PetrolAmount = table.Column<int>(type: "int", nullable: false),
                    PetrolPricePerLiter = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBPetrolSet", x => x.id);
                    table.ForeignKey(
                        name: "FK_DBPetrolSet_DBVehiclesSet_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "DBVehiclesSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DBPetrolSet_VehicleId",
                table: "DBPetrolSet",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBPetrolSet");
        }
    }
}
