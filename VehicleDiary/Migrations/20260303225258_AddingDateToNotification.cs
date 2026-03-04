using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDiary.Migrations
{
    /// <inheritdoc />
    public partial class AddingDateToNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EmailSendDate",
                table: "DBVehiclesSet",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PetrolFueLType",
                table: "DBPetrolSet",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailSendDate",
                table: "DBVehiclesSet");

            migrationBuilder.DropColumn(
                name: "PetrolFueLType",
                table: "DBPetrolSet");
        }
    }
}
