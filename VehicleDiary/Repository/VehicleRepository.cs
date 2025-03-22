using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using VehicleDiary.Data;
using VehicleDiary.Interfaces;
using VehicleDiary.Models;

namespace VehicleDiary.Repository
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

		public async Task<DBVehicleModel?> AddingTotalCostRepairAsync(int id, int cost)
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

		public async Task<int> CalculatingTotalCostRepairAsync(int id)
		{
			return await _context.DBRepairsSet.Where(find => find.VehicleId == id).SumAsync(calculate => calculate.RepairCost);
		}
	}
}
