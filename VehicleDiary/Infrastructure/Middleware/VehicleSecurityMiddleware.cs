using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VehicleDiary.Infrastructure.Data;

namespace VehicleDiary.Infrastructure.Middleware
{
    public class VehicleSecurityMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly IServiceScopeFactory _scopeFactory;

        public VehicleSecurityMiddleware(RequestDelegate next, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _scopeFactory = scopeFactory;
        }
        //Pro každý HTTP request se tento middleware sleduje, jestli query request neobsahuje vehicleIDRoute, jestli ano, tak se zapne podmínka, je to aby uživatel nemohl změnit URL na jiné auto a viděl od cizích lidí 
        // auta, i přes to, že to mám Guid aby byla menší šance, tak to musí být na 100%, kod obsahuje Scope, protože middleware scoped není a já musím prácovat s DB, takže jsem si ho musel vyvolat.
        public async Task Invoke(HttpContext httpcontext)
        {
            if (httpcontext.Request.Query.ContainsKey("vehicleIDRoute"))
            {
                Guid.TryParse(httpcontext.Request.Query["vehicleIDRoute"], out Guid vehicleID);
                var userId = httpcontext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


                using (var scope = _scopeFactory.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var vehicle = await _context.DBVehiclesSet.FirstOrDefaultAsync(find => find.Id == vehicleID && find.UserId == userId);
                    if (vehicle == null)
                    {
                        httpcontext.Response.StatusCode = 403;
                        return;
                    }
                }

            }
            await _next(httpcontext);
        }
    }
}
