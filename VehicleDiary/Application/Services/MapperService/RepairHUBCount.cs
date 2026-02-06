using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Infrastructure.Data;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Services.MapperService
{
    public class RepairHUBCount : IRepairHUBCount
    {
        private readonly IRepositoryVehicle _repositoryVehicle;

        public RepairHUBCount(IRepositoryVehicle repositoryVehicle)
        {
            _repositoryVehicle = repositoryVehicle;
        }
        public async Task<float> TotalCostRepairAsync(Guid vehicleIDRoute)
        {
            return await _repositoryVehicle.CalculatingTotalCostRepairAsync(vehicleIDRoute);
        }
        public async Task<float> TotalCostUpgradeAsync(Guid vehicleIDRoute)
        {
            return await _repositoryVehicle.CalculatingTotalCostUpgradeAsync(vehicleIDRoute);
        }
        public async Task<float> TotalCostDiagnosticAsync(Guid vehicleIDRoute)
        {
            return await _repositoryVehicle.CalculatingTotalCostDiagnosticAsync(vehicleIDRoute);
        }

    }
}
