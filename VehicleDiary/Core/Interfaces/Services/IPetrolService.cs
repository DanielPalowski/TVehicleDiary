using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IPetrolService
    {
        Task<IEnumerable<PetrolDto>>? GetAllPetrolModelsAsync(Guid vehicleIDRoute);
        Task AddingPetrolAsync(PetrolDto petrolDto);
    }
}
