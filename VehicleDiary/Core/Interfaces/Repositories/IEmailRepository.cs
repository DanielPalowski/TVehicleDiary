using System.Security.Claims;

namespace VehicleDiary.Core.Interfaces.Repositories
{
    public interface IEmailRepository
    {
        Task EmailVignetteSender(Guid vehicleIDRoute, ClaimsPrincipal User);
        Task EmailVehicleSender(ClaimsPrincipal User);
    }
}
