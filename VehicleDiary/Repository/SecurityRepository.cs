using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VehicleDiary.Data;
using VehicleDiary.Models;

namespace VehicleDiary.Repository
{
    public class SecurityRepository<T> : IRepositorySecurity<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public SecurityRepository(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context; 
            _userManager = userManager;
        }
        public async Task<DBVehicleModel?> CheckUser(int id, ClaimsPrincipal user)
        {
            var User = _userManager.GetUserId(user);
            return await _context.DBVehiclesSet.FirstOrDefaultAsync(check => check.Id == id && check.UserId == User);
        }

    }
}
