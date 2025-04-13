using System.Security.Claims;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace VehicleDiary.Core.Interfaces.Repositories
{
    public interface IRepositoryCrud<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid vehicleID);

    }
}
