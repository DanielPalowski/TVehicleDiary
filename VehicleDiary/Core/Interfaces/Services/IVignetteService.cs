using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Interfaces.Repositories;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IVignetteService
    {
        Task<IEnumerable<VignetteDto>>? GettingVignetteAsync(Guid vehicleIDRoute);
        Task AddingVignetteAsync(VignetteDto vignette);
        Task RemovingAsync(Guid Id);

    }
}
