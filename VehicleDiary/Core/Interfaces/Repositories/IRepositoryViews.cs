namespace VehicleDiary.Core.Interfaces.Repositories
{
    public interface IRepositoryViews<T> where T : class
    {
        // Generic repositories který vyvolává GET data z DB do view přes controller, místo toho abych dělal všechny repositories, tak jsem udělal jednu generic
        // která inherentuje z interface IVehicleEntity, protože pracuji s vehicleID a všechny modely DB které mají vehicleID tak taky inheretují
        Task<IEnumerable<T>>? GetDBByVehicle(Guid id);
    }
}
