using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VehicleDiary.Models;
using VehicleDiary.Repository;
using VehicleDiary.Services;
using VehicleDiary.ViewModel;

namespace VehicleDiary.Controllers
{
    [Authorize]
    public class CarUsageController : Controller
    {
        private readonly IRepositoryCrud<DBPetrolModel> _repositoryPetrol;
        private readonly IRepositoryCrud<DBVignetteModel> _repositoryVignette;
        private readonly IRepositoryViews<DBPetrolModel> _repositoryView;
        private readonly CountryService _countryService;
        public CarUsageController(IRepositoryCrud<DBPetrolModel> repository,
            IRepositoryViews<DBPetrolModel> repositoryView,
            CountryService countryService,
            IRepositoryCrud<DBVignetteModel> repositoryVignette)

        {
            _repositoryPetrol = repository;
            _repositoryView = repositoryView;
            _countryService = countryService;
            _repositoryVignette = repositoryVignette;
        }
		public async Task<IActionResult> Index([FromQuery] Guid vehicleIDRoute)
        {
            var CarUsage = await _repositoryView.GetDBByVehicle(vehicleIDRoute);
            var ViewModelDB = new CarUsageModelVM
            {
                vehicleID = vehicleIDRoute,
                GettingViews = CarUsage
            };

			return View(ViewModelDB);
        }




        //---------------PETROL---------------
		public async Task<IActionResult> Petrol([FromQuery] Guid vehicleIDRoute)
        {
            var model = new DBPetrolModelVM { vehicleId = vehicleIDRoute };
            return View(model);
        }
        [HttpPost]
		public async Task<IActionResult> Petrol( DBPetrolModelVM dBPetrolModelVM)
        {
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
                await _repositoryPetrol.AddAsync(dbVM);
                //Musí být abych zpátky měl ID daného vozidla, jinak bych dostal Unauthorized
                return RedirectToAction("Index", new { vehicleIDRoute = dBPetrolModelVM.vehicleId });
            }
            return View(dBPetrolModelVM);
        }




		//---------------VIGNETTE---------------
		public async Task<IActionResult> Vignette([FromQuery] Guid vehicleIDRoute)
        {
            ViewBag.Countries = _countryService.GetCountries();
            var model = new DBVignetteModelVM { vehicleId = vehicleIDRoute };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Vignette(DBVignetteModelVM dBVignetteModelVM)
        {
            if(ModelState.IsValid)
            {
                var dbVM = new DBVignetteModel
                {
                    VignetteCountry = dBVignetteModelVM.Country,
                    VignetteValidFrom = dBVignetteModelVM.ValidFrom,
                    VignetteValidTo = dBVignetteModelVM.ValidTo,
                    VignettePrice = dBVignetteModelVM.Price,
                    VehicleId = dBVignetteModelVM.vehicleId
                };
                await _repositoryVignette.AddAsync(dbVM);
                return RedirectToAction("Index", new { vehicleIDRoute = dBVignetteModelVM.vehicleId });

            }
            return View(dBVignetteModelVM);
        }
    }
}
