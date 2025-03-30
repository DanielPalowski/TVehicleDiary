using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDiary.Migrations
{
    /// <inheritdoc />
    public partial class AddingTiresToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBTiresSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TirePrice = table.Column<float>(type: "real", nullable: false),
                    TireAmount = table.Column<int>(type: "int", nullable: false),
                    TireBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireType = table.Column<bool>(type: "bit", nullable: false),
                    TireSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TireDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBTiresSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBTiresSet_DBVehiclesSet_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "DBVehiclesSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DBTiresSet_VehicleId",
                table: "DBTiresSet",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBTiresSet");
        }
    }
}
