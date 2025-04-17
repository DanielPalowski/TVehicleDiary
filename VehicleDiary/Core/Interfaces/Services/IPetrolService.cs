using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IPetrolService
    {
        Task<IEnumerable<PetrolDto>>? GetAllPetrolModelsAsync(Guid vehicleIDRoute);
        Task AddingPetrolAsync(PetrolDto petrolDto);
        Task RemovingAsync(Guid Id);
    }
}
