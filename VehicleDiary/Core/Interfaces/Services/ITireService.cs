using VehicleDiary.Application.DTOs;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface ITireService
    {
        Task<IEnumerable<TireDto>>? GetAllTiresAsync(Guid vehicleIDRoute);
        Task AddingNewTiresAsync(TireDto tireDto);
    }
}
