using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Models;
using VehicleDiary.Repository;
using VehicleDiary.ViewModel;

namespace VehicleDiary.Controllers
{
    [Authorize]
    public class CarUsageController : Controller
    {
        private readonly IRepositoryCrud<DBPetrolModel> _repository;
        private readonly IRepositorySecurity<DBVehicleModel> _repositorySecurity;
        private readonly IRepositoryViews<DBPetrolModel> _repositoryView;
        public CarUsageController(IRepositoryCrud<DBPetrolModel> repository,
            IRepositorySecurity<DBVehicleModel> repositorysecurity,
            IRepositoryViews<DBPetrolModel> repositoryView)

        {
            _repository = repository;
            _repositorySecurity = repositorysecurity;
            _repositoryView = repositoryView;

        }
        public async Task<IActionResult> Index(int vehicleIDRoute)
        {
            if (await _repositorySecurity.CheckUser(vehicleIDRoute, User) == null)
            {
                return Unauthorized();
            }

            ViewBag.VehicleIDBag = vehicleIDRoute;
            return View(await _repositoryView.GetDBByVehicle(vehicleIDRoute));
        }
        public async Task<IActionResult> Petrol(int vehicleIDRoute)
        {
            if (await _repositorySecurity.CheckUser(vehicleIDRoute, User) == null)
            {
                return Unauthorized();
            }

            var model = new DBPetrolModelVM { vehicleId = vehicleIDRoute };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Petrol( DBPetrolModelVM dBPetrolModelVM)
        {
            if (await _repositorySecurity.CheckUser(dBPetrolModelVM.vehicleId, User) == null)
            {
                return Unauthorized();
            }

            if (ModelState.IsValid) 
            {
                var dbVM = new DBPetrolModel
                {
                    PetrolAmount = dBPetrolModelVM.PetrolAmount,
                    PetrolPrice = dBPetrolModelVM.PetrolPrice,
                    PetrolType = dBPetrolModelVM.PetrolType,
                    PetrolDate = dBPetrolModelVM.PetrolDate,
                    PetrolMileage = dBPetrolModelVM?.PetrolMileage,
                    VehicleId = dBPetrolModelVM.vehicleId
                };
                await _repository.AddAsync(dbVM);
                //Musí být abych zpátky měl ID daného vozidla, jinak bych dostal Unauthorized
                return RedirectToAction("Index", new { vehicleIDRoute = dBPetrolModelVM.vehicleId });
            }
            return View();
        }
    }
}
