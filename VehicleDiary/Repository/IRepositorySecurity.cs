using System.Security.Claims;
using VehicleDiary.Models;

namespace VehicleDiary.Repository
{
    public interface IRepositorySecurity<T> where T : class
    {
        //většina controlleru potřebují checkovat, aby uživatel pri ID routing v URL nemohl změnit ID a podívat se ostatním do jejích DB, tak místo to, aby udělatl
        // jeden a ten samý kod ve všech repositories, udělal jsem jednu generic, která stejnák vyvolává z DBVehicleModel, protože tam je ID daného vozidla
        // ale pro budoucnost chci přidat další security možnosti, takže jsem ji prozatím udělal Generic
        Task<DBVehicleModel?> CheckUser(int id, ClaimsPrincipal user);
        
    }
}
