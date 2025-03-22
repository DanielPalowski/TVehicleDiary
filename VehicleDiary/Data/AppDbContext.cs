using Microsoft.EntityFrameworkCore;
using VehicleDiary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace VehicleDiary.Data
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<DBVehicleModel> DBVehiclesSet { get; set; }
        public DbSet<DBRepairsModel> DBRepairsSet { get; set;}
        public DbSet<DBPetrolModel> DBPetrolSet { get; set;}
    }
}
