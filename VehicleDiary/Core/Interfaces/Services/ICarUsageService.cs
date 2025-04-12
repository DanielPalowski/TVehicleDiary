using VehicleDiary.Application.DTOs;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface ICarUsageService
    {
        Task<TireDto> LatestTireUsageAsync(Guid vehicleIDRoute);
        Task<PetrolDto> LatestPetrolUsageAsync(Guid vehicleIDRoute);
        Task<VignetteDto> LatestVignetteUsageAsync(Guid vehicleIDRoute);
        Task<OilDto> LatestOilUsageAsync(Guid vehicleIDRoute);

    }
}
