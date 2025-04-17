using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Interfaces.Repositories;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface ITireService
    {
        Task<IEnumerable<TireDto>>? GetAllTiresAsync(Guid vehicleIDRoute);
        Task AddingNewTiresAsync(TireDto tireDto);
        Task RemovingAsync(Guid Id);
    }
}
