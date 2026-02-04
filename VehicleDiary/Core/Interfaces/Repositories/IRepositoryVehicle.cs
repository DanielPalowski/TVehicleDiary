namespace VehicleDiary.Core.Interfaces.Repositories;

using Microsoft.EntityFrameworkCore;
using VehicleDiary.Core.Entities;

public interface IRepositoryVehicle : IRepositoryCrud<DBVehicleModel>
{
    Task<float> CalculatingTotalCostRepairAsync(Guid id);
    Task<float> CalculatingTotalCostUpgradeAsync(Guid id);
   // Task<float> CalculatingTotalCostDiagnosticAsync(Guid id);

    Task<DBVehicleModel?> AddingTotalCostRepairAsync(Guid id, float cost);
    Task<IEnumerable<DBVehicleModel>> GetDBByIDForUserAsync(string userID);
    Task TryRemoveByIdAsync<TEntity>(DbSet<TEntity> dbSet, Guid id) where TEntity : class;
}

