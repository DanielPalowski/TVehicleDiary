using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IDiagnosticVehicleService
    {
        Task<IEnumerable<DiagnosticVehicleDto>> GettingRepairViewAsync(Guid vehicleIDRoute);
        Task<Guid> AddingRepairAsync(DiagnosticVehicleDto repairDto);
        Task RemovingAsync(Guid Id);
        Task UploadingAsync(DiagnosticVehicleDto repairDto);
        Task<FileContentResult> DownloadingAsync(Guid id);
    }
}
