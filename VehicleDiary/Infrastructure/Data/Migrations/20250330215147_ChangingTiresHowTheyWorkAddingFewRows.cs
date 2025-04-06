using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDiary.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTiresHowTheyWorkAddingFewRows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TireType",
                table: "DBTiresSet",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<float>(
                name: "TireChangedPrice",
                table: "DBTiresSet",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "TireShopWhereBought",
                table: "DBTiresSet",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TireChangedPrice",
                table: "DBTiresSet");

            migrationBuilder.DropColumn(
                name: "TireShopWhereBought",
                table: "DBTiresSet");

            migrationBuilder.AlterColumn<bool>(
                name: "TireType",
                table: "DBTiresSet",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
