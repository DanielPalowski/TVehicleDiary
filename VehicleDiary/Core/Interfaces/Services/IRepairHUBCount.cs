namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IRepairHUBCount
    {
        Task CountingRepairsAsync(Guid repairId);
    }
}
