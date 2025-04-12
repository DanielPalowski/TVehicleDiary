using VehicleDiary.Core.Entities;

namespace VehicleDiary.Core.Interfaces.Repositories
{
    public interface IRepositoryCarUsage
    {
        Task<DBVignetteModel?> GettingLatestVignetteAsync(Guid vehicleIDRoute);
        Task<DBPetrolModel?> GettingLatestPetrolAsync(Guid vehicleIDRoute);
        Task<DBOilModel?> GettingLatestOilAsync(Guid vehicleIDRoute);
        Task<DBTiresModel?> GettingLatestTiresAsync(Guid vehicleIDRoute);

    }
}
