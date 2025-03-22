using System.Security.Claims;
using VehicleDiary.Models;

namespace VehicleDiary.Repository
{
    public interface IRepositoryCrud<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync (int id);
        Task AddAsync (T entity);
        Task UpdateAsync (T entity);
        Task DeleteAsync (int id);
        Task<int> SaveChangesAsync();
        Task <IEnumerable<T>> GetDBByIDForUserAsync (ClaimsPrincipal user);
       
    }
}
