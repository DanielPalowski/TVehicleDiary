using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VehicleDiary.Data;
using VehicleDiary.Interfaces;

namespace VehicleDiary.Repository
{
    public class ViewsRepository<T> : IRepositoryViews<T> where T : class, IVehicleEntity
    {
        private readonly AppDbContext _context;
        public ViewsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T?>> GetDBByVehicle(int id)
        {
            return await _context.Set<T>().Where(x => x.VehicleId == id).ToListAsync();
        }
    }
}
