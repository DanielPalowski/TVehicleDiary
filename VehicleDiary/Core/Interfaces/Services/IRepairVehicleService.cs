using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IRepairVehicleService
    {
        Task<IEnumerable<RepairVehicleDto>> GettingRepairViewAsync(Guid vehicleIDRoute);
        Task<Guid> AddingRepairAsync(RepairVehicleDto repairDto);
        Task RemovingAsync(Guid Id);
        Task UploadingAsync(RepairVehicleDto repairDto);
        Task<FileContentResult> DownloadingAsync(Guid id);
    }
}
