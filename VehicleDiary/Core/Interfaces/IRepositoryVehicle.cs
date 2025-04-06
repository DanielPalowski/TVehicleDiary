namespace VehicleDiary.Core.Interfaces;

using Microsoft.EntityFrameworkCore;
using VehicleDiary.Core.Entities;

public interface IRepositoryVehicle : IRepositoryCrud<DBVehicleModel>
{
    Task<float> CalculatingTotalCostRepairAsync(Guid id);
    Task<DBVehicleModel?> AddingTotalCostRepairAsync(Guid id, float cost);
    Task<IEnumerable<DBVehicleModel>> GetDBByIDForUserAsync(string userID);
}

