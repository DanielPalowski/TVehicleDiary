using VehicleDiary.Core.Entities;

namespace VehicleDiary.Core.Interfaces
{
    public interface IRepositoryCarUsage
    {
        Task<DBVignetteModel?> GettingLatestVignetteAsync(Guid vehicleIDRoute);
    }
}
