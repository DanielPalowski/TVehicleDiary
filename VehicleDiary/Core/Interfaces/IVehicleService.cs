using VehicleDiary.Application.DTOs;

namespace VehicleDiary.Core.Interfaces
{
    public interface IVehicleService
    {
        Task AddVehicleAsync(VehicleDto vehicleDto);
        Task<IEnumerable<VehicleDto>> GettingVehiclesAsync(string userID); 
    }
}
