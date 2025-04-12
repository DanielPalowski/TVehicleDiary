using Microsoft.EntityFrameworkCore;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
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
        .OrderByDescending(v => v.Created) 
        .FirstOrDefaultAsync();

            return latestVignette;
        }
        public async Task<DBPetrolModel?> GettingLatestPetrolAsync (Guid vehicleIDRoute)
        {
            var lattestPetrol = await _context.DBPetrolSet.Where(find => find.VehicleId == vehicleIDRoute)
                .OrderByDescending(find => find.Created)
                .FirstOrDefaultAsync();

            return lattestPetrol;
        }
        public async Task<DBOilModel?> GettingLatestOilAsync(Guid vehicleIDRoute)
        {
            var lattestOil = await _context.DBOilSet.Where(find => find.VehicleId == vehicleIDRoute)
                .OrderByDescending(find => find.Created)
                .FirstOrDefaultAsync();

            return lattestOil;
        }
        public async Task<DBTiresModel?> GettingLatestTiresAsync(Guid vehicleIDRoute)
        {
            var lattestTires = await _context.DBTiresSet.Where(find => find.VehicleId == vehicleIDRoute)
                .OrderByDescending(find => find.Created)
                .FirstOrDefaultAsync();

            return lattestTires;
        }
    }
}
