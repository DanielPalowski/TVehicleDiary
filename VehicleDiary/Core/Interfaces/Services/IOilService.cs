using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IOilService
    {
        Task<IEnumerable<OilDto>>? GettingOiLViewAsync(Guid vehicleIDRoute);
        Task AddingOilAsync(OilDto oilDto);
    }
}
