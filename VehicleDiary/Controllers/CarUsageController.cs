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
        private readonly IRepositoryCrud<DBOilModel> _repositoryOil;
        private readonly IRepositoryCrud<DBTiresModel> _repositoryTires;
        private readonly IRepositoryViews<DBPetrolModel> _repositoryView;
        private readonly CountryService _countryService;
        public CarUsageController(IRepositoryCrud<DBPetrolModel> repository,
            IRepositoryViews<DBPetrolModel> repositoryView,
            CountryService countryService,
            IRepositoryCrud<DBVignetteModel> repositoryVignette,
            IRepositoryCrud<DBOilModel> repositoryOil,
            IRepositoryCrud<DBTiresModel> repositoryTires)

        {
            _repositoryPetrol = repository;
            _repositoryView = repositoryView;
            _countryService = countryService;
            _repositoryVignette = repositoryVignette;
            _repositoryOil = repositoryOil;
            _repositoryTires = repositoryTires;

        }
		public async Task<IActionResult> Index([FromQuery] Guid vehicleIDRoute)
        {
            var CarUsage = await _repositoryView.GetDBByVehicle(vehicleIDRoute);
            var ViewModelDB = new DBCarUsageModelVM
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




		//---------------OIL---------------
        public async Task<IActionResult> Oil([FromQuery] Guid vehicleIDRoute)
        {
            var model = new DBOilModelVM { VehicleId = vehicleIDRoute };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Oil(DBOilModelVM dBOilModelVM)
        {
            if(ModelState.IsValid)
            {
                var dbVM = new DBOilModel
                {
                    OilAmount = dBOilModelVM.OilAmount,
                    OilDate = dBOilModelVM.OilDate,
                    OilMileage = dBOilModelVM.OilMileage,
                    OilPrice = dBOilModelVM.OilPrice,
                    OilType = dBOilModelVM.OilType,
                    VehicleId = dBOilModelVM.VehicleId
                };
                await _repositoryOil.AddAsync(dbVM);
                return RedirectToAction("Index", new { vehicleIDRoute = dBOilModelVM.VehicleId });

            }
            return View(dBOilModelVM);
        }





        //-----------------Tires-------------
        public async Task<IActionResult> Tires([FromQuery] Guid vehicleIDRoute)
        {
            var model = new DBTiresModelVM { VehicleId = vehicleIDRoute };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Tires (DBTiresModelVM dBTiresModelVM)
        {
            if(ModelState.IsValid)
            {
                var dbVM = new DBTiresModel
                {
                    TireAmount = dBTiresModelVM.TireAmount,
                    TireBrand = dBTiresModelVM.TireBrand,
                    TireDate = dBTiresModelVM.TireDate,
                    TireDescription = dBTiresModelVM.TireDescription,
                    TirePrice = dBTiresModelVM.TirePrice,
                    TireSize = dBTiresModelVM.TireSize,
                    TireType = dBTiresModelVM.TireType,
                    TireChangedPrice = dBTiresModelVM.TireChangedPrice,
                    TireShopWhereBought = dBTiresModelVM.TireShopWhereBought,
                    VehicleId = dBTiresModelVM.VehicleId
                };
                await _repositoryTires.AddAsync(dbVM);
                return RedirectToAction("Index", new { vehicleIdRoute = dBTiresModelVM.VehicleId});
            }
            return View(dBTiresModelVM);
        }
	}
}
