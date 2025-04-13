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
            return await _context.DBRepairsSet.Where(find => find.VehicleId == id).SumAsync(calculate => calculate.RepairCost);
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
