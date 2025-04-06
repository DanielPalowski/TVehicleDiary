using Microsoft.EntityFrameworkCore;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces;
using VehicleDiary.Infrastructure.Data;

namespace VehicleDiary.Infrastructure.Repositories
{
    public class CarUsageRepository : IRepositoryCarUsage
    {
        private readonly AppDbContext _context;
        public CarUsageRepository(AppDbContext context)
        { 
            _context = context;
        }
        public async Task<DBVignetteModel?> GettingLatestVignetteAsync(Guid vehicleIDRoute)
        {
            var latestVignette = await _context.DBVignetteSet
        .Where(v => v.VehicleId == vehicleIDRoute)
        .OrderByDescending(v => v.VignetteValidFrom) 
        .FirstOrDefaultAsync();

            return latestVignette;
        }
    }
}
