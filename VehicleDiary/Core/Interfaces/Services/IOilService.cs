using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IOilService
    {
        Task<IEnumerable<OilDto>>? GettingOiLViewAsync(Guid vehicleIDRoute);
        Task AddingOilAsync(OilDto oilDto);
        Task RemovingAsync(Guid Id);
    }
}
