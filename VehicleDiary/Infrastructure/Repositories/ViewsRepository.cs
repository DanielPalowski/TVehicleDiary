using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VehicleDiary.Core.Interfaces;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Infrastructure.Data;

namespace VehicleDiary.Infrastructure.Repositories
{
    public class ViewsRepository<T> : IRepositoryViews<T> where T : class, IVehicleEntity
    {
        private readonly AppDbContext _context;
        public ViewsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>>? GetDBByVehicle(Guid id)
        {
            return await _context.Set<T>().Where(x => x.VehicleId == id).ToListAsync();
        }
    }
}
