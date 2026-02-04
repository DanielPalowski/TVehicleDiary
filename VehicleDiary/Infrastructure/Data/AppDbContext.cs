using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VehicleDiary.Core.Entities;
using System.Security.Permissions;



namespace VehicleDiary.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<DBVehicleModel> DBVehiclesSet { get; set; }
        public DbSet<DBRepairsModel> DBRepairsSet { get; set; }
        public DbSet<DBPetrolModel> DBPetrolSet { get; set; }
        public DbSet<DBVignetteModel> DBVignetteSet { get; set; }
        public DbSet<DBOilModel> DBOilSet { get; set; }
        public DbSet<DBTiresModel> DBTiresSet { get; set; }
        public DbSet<DBRepairVehicleModel> DBRepairVehicleSet { get; set; }
        public DbSet<DBUpgradeVehicleModel> DBUpgradeVehicleSet { get;set; }
        public DbSet<DBDiagnosticVehicleModel> DBDiagnosticVehicleSet { get; set; }
    }
}
