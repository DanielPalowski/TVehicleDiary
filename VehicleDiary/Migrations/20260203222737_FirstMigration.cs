using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleDiary.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBVehiclesSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    MadeYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    STK = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    License_plate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    VIN = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Power = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Insurence = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Bought = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepairCost = table.Column<float>(type: "real", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBVehiclesSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBVehiclesSet_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBDiagnosticVehicleSet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiagnosticVCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiagnosticVType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiagnosticVErrorType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DiagnosticVName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiagnosticVErrorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiagnosticVErrorDis = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiagnosticVDiagnosticType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiagnosticVMileage = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    DiagnosticVWhen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiagnosticVPrice = table.Column<float>(type: "real", maxLength: 20, nullable: false),
                    DiagnosticVNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpgradeVTechnician = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBDiagnosticVehicleSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DBDiagnosticVehicleSet_DBVehiclesSet_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "DBVehiclesSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBOilSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OilAmount = table.Column<float>(type: "real", nullable: false),
                    OilDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OilType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OilMileage = table.Column<int>(type: "int", nullable: false),
                    OilPrice = table.Column<float>(type: "real", nullable: false),
                    OilDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBOilSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBOilSet_DBVehiclesSet_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "DBVehiclesSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBPetrolSet",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetrolDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PetrolType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetrolMileage = table.Column<int>(type: "int", nullable: true),
                    PetrolPrice = table.Column<float>(type: "real", nullable: false),
                    PetrolAmount = table.Column<float>(type: "real", nullable: false),
                    PetrolPricePerLiter = table.Column<float>(type: "real", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "DBRepairsSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepairType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairCost = table.Column<float>(type: "real", nullable: false),
                    RepairMade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepairMileage = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBRepairsSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DBRepairsSet_DBVehiclesSet_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "DBVehiclesSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBRepairVehicleSet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepairVCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RepairVType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RepairVName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairVPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairVMileage = table.Column<int>(type: "int", nullable: false),
                    RepairVWhen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepairVPrice = table.Column<float>(type: "real", nullable: false),
                    ReapairVNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairVTechnician = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairVPartBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepairVPartCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBRepairVehicleSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DBRepairVehicleSet_DBVehiclesSet_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "DBVehiclesSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBTiresSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TirePrice = table.Column<float>(type: "real", nullable: false),
                    TireAmount = table.Column<int>(type: "int", nullable: false),
                    TireBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireType = table.Column<int>(type: "int", nullable: false),
                    TireSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TireChangedPrice = table.Column<float>(type: "real", nullable: true),
                    TireShopWhereBought = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "DBUpgradeVehicleSet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpgradeVCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpgradeVType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpgradeVStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpgradeVName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UpgradeVMileage = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    UpgradeVWhen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpgradeVPrice = table.Column<float>(type: "real", maxLength: 20, nullable: false),
                    UpgradeVNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpgradeVTechnician = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpgradeVPartBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpgradeVPartCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBUpgradeVehicleSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DBUpgradeVehicleSet_DBVehiclesSet_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "DBVehiclesSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DBVignetteSet",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VignetteCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VignetteValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VignetteValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VignettePrice = table.Column<float>(type: "real", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBVignetteSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DBVignetteSet_DBVehiclesSet_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "DBVehiclesSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DBDiagnosticVehicleSet_VehicleId",
                table: "DBDiagnosticVehicleSet",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_DBOilSet_VehicleId",
                table: "DBOilSet",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_DBPetrolSet_VehicleId",
                table: "DBPetrolSet",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_DBRepairsSet_VehicleId",
                table: "DBRepairsSet",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_DBRepairVehicleSet_VehicleId",
                table: "DBRepairVehicleSet",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_DBTiresSet_VehicleId",
                table: "DBTiresSet",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_DBUpgradeVehicleSet_VehicleId",
                table: "DBUpgradeVehicleSet",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_DBVehiclesSet_UserId",
                table: "DBVehiclesSet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DBVignetteSet_VehicleId",
                table: "DBVignetteSet",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DBDiagnosticVehicleSet");

            migrationBuilder.DropTable(
                name: "DBOilSet");

            migrationBuilder.DropTable(
                name: "DBPetrolSet");

            migrationBuilder.DropTable(
                name: "DBRepairsSet");

            migrationBuilder.DropTable(
                name: "DBRepairVehicleSet");

            migrationBuilder.DropTable(
                name: "DBTiresSet");

            migrationBuilder.DropTable(
                name: "DBUpgradeVehicleSet");

            migrationBuilder.DropTable(
                name: "DBVignetteSet");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DBVehiclesSet");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
