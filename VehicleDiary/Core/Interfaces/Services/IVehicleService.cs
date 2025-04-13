using VehicleDiary.Application.DTOs;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IVehicleService
    {
        Task AddVehicleAsync(VehicleDto vehicleDto);
        Task<IEnumerable<VehicleDto>> GettingVehiclesAsync(string userID);
        Task DeleteVehicleAsync(Guid vehicleID);
    }
}
