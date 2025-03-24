using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDiary.Migrations
{
    /// <inheritdoc />
    public partial class RepairingVignetteNameAndAddingCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValidTo",
                table: "DBVignetteSet",
                newName: "VignetteValidTo");

            migrationBuilder.RenameColumn(
                name: "ValidFrom",
                table: "DBVignetteSet",
                newName: "VignetteValidFrom");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "DBVignetteSet",
                newName: "VignettePrice");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "DBVignetteSet",
                newName: "VignetteCountry");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "DBVignetteSet",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "DBVignetteSet");

            migrationBuilder.RenameColumn(
                name: "VignetteValidTo",
                table: "DBVignetteSet",
                newName: "ValidTo");

            migrationBuilder.RenameColumn(
                name: "VignetteValidFrom",
                table: "DBVignetteSet",
                newName: "ValidFrom");

            migrationBuilder.RenameColumn(
                name: "VignettePrice",
                table: "DBVignetteSet",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "VignetteCountry",
                table: "DBVignetteSet",
                newName: "Country");
        }
    }
}
