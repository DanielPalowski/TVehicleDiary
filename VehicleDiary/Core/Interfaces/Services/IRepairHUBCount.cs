namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IRepairHUBCount
    {
        Task<float> TotalCostRepairAsync(Guid vehicleIDRoute);
        Task<float> TotalCostUpgradeAsync(Guid vehicleIDRoute);
        Task<float> TotalCostDiagnosticAsync(Guid vehicleIDRoute);
    }
}
