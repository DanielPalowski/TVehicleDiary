using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IVehicleService
    {
        Task AddVehicleAsync(VehicleDto vehicleDto);
        Task<IEnumerable<VehicleDto>> GettingVehiclesAsync(string userID);
        Task DeleteVehicleAsync(Guid vehicleID);
        Task<int> CountingVehiclesAsync(string userID);
        Task<List<DBVehicleModel>> GetVehiclesWithTotalCostAsync(string userId);
        Task<int> GetTotalNumberOfCars();
        Task<int> GetTotalNumberOfUsers();
        Task<int> GetTotalNumberOfServices();

    }
}
