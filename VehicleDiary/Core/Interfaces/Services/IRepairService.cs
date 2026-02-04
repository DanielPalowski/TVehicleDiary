using VehicleDiary.Application.DTOs;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IRepairService
    {
        Task<float> TotalCostAsync(Guid vehicleIDRoute);
        Task<IEnumerable<RepairDto>>? ShowingRepairsAsync(Guid vehicleIDRoute);
        Task AddingRepairAsync(RepairDto repairDto);
        Task RemovingAsync(Guid vehicleIDRoute);
    }
}
