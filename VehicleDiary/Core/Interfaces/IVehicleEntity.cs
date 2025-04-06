namespace VehicleDiary.Core.Interfaces
{
    // Často používám VehicleID a nechci aby se kod opakoval v repository, ale nemůžu udělat generic repository, když funkce v metodách používají VehicleID z dané
    // databáze, takže všechny Modely DB které mají vehicle ID inheretují z tohoto interface a poté můžu udělat generic repository pro mé controllery například
    // na vyvolání dat do view, nechci dělat 3 repositories, které dělají to stejné, tak udělám jednu generic pro 3 controllery
    // snažím se aby se kód co nejméně opakoval
    public interface IVehicleEntity
    {
        Guid VehicleId { get; set; }
    }
}
