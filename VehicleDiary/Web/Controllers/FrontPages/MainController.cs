using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers.FrontPages
{
    public class MainController : Controller
    {
        private readonly IVehicleService _vehicleService;
        public MainController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        public async Task<IActionResult> Index()
        {
            int cars = await _vehicleService.GetTotalNumberOfCars();
            int users = await _vehicleService.GetTotalNumberOfUsers();
            int services = await _vehicleService.GetTotalNumberOfServices();
            var returns = new DBMainModelVM
            {
                TotalCars = cars,
                TotalUsers = users,
                TotalServices = services
            };
            return View(returns);
        }
    }
}
