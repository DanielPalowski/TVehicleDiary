using VehicleDiary.Core.Entities;

namespace VehicleDiary.Core.Interfaces.Repositories
{
    public interface IRepositoryCarUsage
    {
        Task<DBVignetteModel?> GettingLatestVignetteAsync(Guid vehicleIDRoute);
    }
}
