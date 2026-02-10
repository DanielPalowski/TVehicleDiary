using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Infrastructure.Data;

namespace VehicleDiary.Infrastructure.Repositories
{
    public class VehicleRepository : CrudRepository<DBVehicleModel>, IRepositoryVehicle
    {
        public readonly AppDbContext _context;
        public readonly UserManager<IdentityUser> _userManager;
        public VehicleRepository(AppDbContext context, UserManager<IdentityUser> userManager) : base(context, userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<DBVehicleModel?> AddingTotalCostRepairAsync(Guid id, float cost)
        {

            var vehicle = await _context.DBVehiclesSet.FirstOrDefaultAsync(x => x.Id == id);
            if (vehicle == null)
            {
                return null;
            }
            vehicle.RepairCost = cost;
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<float> CalculatingTotalCostRepairAsync(Guid id)
        {
            return await _context.DBRepairVehicleSet.Where(find => find.VehicleId == id).SumAsync(calculate => calculate.RepairVPrice);
        }
        public async Task<float> CalculatingTotalCostUpgradeAsync(Guid id)
        {
            return await _context.DBUpgradeVehicleSet.Where(find => find.VehicleId == id).SumAsync(calculate => calculate.UpgradeVPrice);
        }
        public async Task<float> CalculatingTotalCostDiagnosticAsync(Guid id)
        {
            return await _context.DBDiagnosticVehicleSet.Where(find => find.VehicleId == id).SumAsync(calculate => calculate.DiagnosticVPrice) ?? 0f;
        }
        public async Task<float> CalculatingTotalCostPetrolAsync(Guid id)
        {
            return await _context.DBPetrolSet.Where(find => find.VehicleId == id).SumAsync(calculate => calculate.PetrolPrice);
        }
        public async Task<float> CalculatingTotalCostOilAsync(Guid id)
        {
            return await _context.DBOilSet.Where(find => find.VehicleId == id).SumAsync(calculate => calculate.OilPrice);
        }
        public async Task<float> CalculatingTotalCostVignetteAsync(Guid id)
        {
            return await _context.DBVignetteSet.Where(find => find.VehicleId == id).SumAsync(calculate => calculate.VignettePrice);
        }
        public async Task<float> CalculatingTotalCostTiresAsync(Guid id)
        {
            return await _context.DBTiresSet.Where(find => find.VehicleId == id).SumAsync(calculate => calculate.TirePrice);
        }
        public async Task<int> CalculatingTotalUsers()
        {
            return await _context.Users.CountAsync();
        }
        public async Task<int> CalculatingTotalCars()
        {
            return await _context.DBVehiclesSet.CountAsync();
        }
        public async Task<int> CalculatingTotalServices()
        {
            return await _context.DBRepairVehicleSet.CountAsync();
        }
        public async Task<List<DBVehicleModel>> GetVehiclesWithTotalCostAsync(string userId)
        {
            var vehicles = await _context.DBVehiclesSet
                .Where(v => v.UserId == userId)
                .ToListAsync();

            foreach (var vehicle in vehicles)
            {
                var repair = await _context.DBRepairVehicleSet
                    .Where(x => x.VehicleId == vehicle.Id)
                    .SumAsync(x => (float?)x.RepairVPrice) ?? 0;

                var upgrade = await _context.DBUpgradeVehicleSet
                    .Where(x => x.VehicleId == vehicle.Id)
                    .SumAsync(x => (float?)x.UpgradeVPrice) ?? 0;

                var diagnostic = await _context.DBDiagnosticVehicleSet
                    .Where(x => x.VehicleId == vehicle.Id)
                    .SumAsync(x => (float?)x.DiagnosticVPrice) ?? 0;

                var petrol = await _context.DBPetrolSet
                    .Where(x => x.VehicleId == vehicle.Id)
                    .SumAsync(x => (float?)x.PetrolPrice) ?? 0;

                var oil = await _context.DBOilSet
                    .Where(x => x.VehicleId == vehicle.Id)
                    .SumAsync(x => (float ?)x.OilPrice) ?? 0;

                var vignette = await _context.DBVignetteSet
                    .Where(x => x.VehicleId == vehicle.Id)
                    .SumAsync(x => (float?)x.VignettePrice) ?? 0;

                var tires = await _context.DBTiresSet
                    .Where(x => x.VehicleId == vehicle.Id)
                    .SumAsync(x => (float?)x.TirePrice) ?? 0;

                vehicle.RepairCost =
                    repair + upgrade + diagnostic + petrol + oil + vignette + tires;
            }

            return vehicles;
        }


        public async Task<IEnumerable<DBVehicleModel>> GetDBByIDForUserAsync(string userID)
        {
            return await _context.Set<DBVehicleModel>().Where(find => find.UserId == userID).ToListAsync();
        }
        public async Task TryRemoveByIdAsync<TEntity>(DbSet<TEntity> dbSet, Guid vehicleID) where TEntity : class
        {
            // musí být volání stringu VehicleId protože to je generic type.
            var entities = await dbSet
                .Where(e => EF.Property<Guid>(e, "VehicleId") == vehicleID)
                .ToListAsync();

            if (entities.Any())
            {
                dbSet.RemoveRange(entities);
            }
        }
    }
}
