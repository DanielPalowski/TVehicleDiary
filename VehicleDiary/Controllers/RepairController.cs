using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleDiary.Constants;
using VehicleDiary.Data;
using VehicleDiary.Migrations;
using VehicleDiary.Models;
using VehicleDiary.Repository;
using VehicleDiary.ViewModel;

namespace VehicleDiary.Controllers
{
    [Authorize]
    public class RepairController : Controller
    {
        public readonly IRepositoryCrud<DBRepairsModel> _repositoryCrudRepair;
        public readonly IRepositorySecurity<DBVehicleModel> _repositorySecurity;
        public readonly IRepositoryViews<DBRepairsModel> _repositoryViews;
        public readonly IRepositoryVehicle _repositoryVehicle;

		public RepairController(IRepositoryCrud<DBRepairsModel> repository,  
            IRepositoryVehicle repositoryVehicle,
            IRepositorySecurity<DBVehicleModel> repositorySecurity,
            IRepositoryViews<DBRepairsModel> repositoryViews)

        {
            _repositoryCrudRepair = repository;
            _repositoryVehicle = repositoryVehicle;
            _repositorySecurity = repositorySecurity;
            _repositoryViews = repositoryViews;

        }
        public async Task<IActionResult> Index(int vehicleIDRoute)
        {
			if (await _repositorySecurity.CheckUser(vehicleIDRoute, User) == null)
			{
				return Redirect("/Identity/Account/AccessDenied");
			}
			ViewBag.vehicleIDBag = vehicleIDRoute;
 
            var total = await _repositoryVehicle.CalculatingTotalCostRepairAsync(vehicleIDRoute);
            await _repositoryVehicle.AddingTotalCostRepairAsync(vehicleIDRoute, total);






            return View(await _repositoryViews.GetDBByVehicle(vehicleIDRoute));
        }
        public async Task<IActionResult> Create(int vehicleIDRoute)
        {
            if (await _repositorySecurity.CheckUser(vehicleIDRoute, User) == null)
			{
				return Redirect("/Identity/Account/AccessDenied");
			}

			var model = new DBRepairModelVM { vehicleId = vehicleIDRoute };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DBRepairModelVM dBRepairModelVM)
        {
			if (await _repositorySecurity.CheckUser(dBRepairModelVM.vehicleId, User) == null)
			{
				return Redirect("/Identity/Account/AccessDenied");
			}

			if (ModelState.IsValid)
            {
                var DBRepair = new DBRepairsModel
                {
                    RepairType = dBRepairModelVM.RepairType,
                    RepairCost = dBRepairModelVM.RepairCost,
                    RepairDescription = dBRepairModelVM.RepairDescription,
                    RepairMade = dBRepairModelVM.RepairMade,
                    VehicleId = dBRepairModelVM.vehicleId,
                    RepairMileage = dBRepairModelVM.RepairMileage
                };
                await _repositoryCrudRepair.AddAsync(DBRepair);
                return RedirectToAction("Index", new { vehicleIDRoute = dBRepairModelVM.vehicleId });
            }
            return View();
        }
    }
}
