using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IUpgradeVehicleService
    {
        Task<IEnumerable<UpgradeVehicleDto>> GettingRepairViewAsync(Guid vehicleIDRoute);
        Task<Guid> AddingRepairAsync(UpgradeVehicleDto repairDto);
        Task RemovingAsync(Guid Id);
        Task UploadingAsync(UpgradeVehicleDto repairDto);
        Task<FileContentResult> DownloadingAsync(Guid id);
        /*Task<int> CountingAsync(Guid vehicleIDRoute);*/
    }
}
