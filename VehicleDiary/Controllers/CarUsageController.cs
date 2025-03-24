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
        private readonly IRepositorySecurity<DBVehicleModel> _repositorySecurity;
        private readonly IRepositoryViews<DBPetrolModel> _repositoryView;
        private readonly CountryService _countryService;
        public CarUsageController(IRepositoryCrud<DBPetrolModel> repository,
            IRepositorySecurity<DBVehicleModel> repositorysecurity,
            IRepositoryViews<DBPetrolModel> repositoryView,
            CountryService countryService,
            IRepositoryCrud<DBVignetteModel> repositoryVignette)

        {
            _repositoryPetrol = repository;
            _repositorySecurity = repositorysecurity;
            _repositoryView = repositoryView;
            _countryService = countryService;
            _repositoryVignette = repositoryVignette;
        }
        public async Task<IActionResult> Index(int vehicleIDRoute)
        {
            if (await _repositorySecurity.CheckUser(vehicleIDRoute, User) == null)
            {
				return Redirect("/Identity/Account/AccessDenied");

			}

            ViewBag.VehicleIDBag = vehicleIDRoute;
            return View(await _repositoryView.GetDBByVehicle(vehicleIDRoute));
        }
        public async Task<IActionResult> Petrol(int vehicleIDRoute)
        {
            if (await _repositorySecurity.CheckUser(vehicleIDRoute, User) == null)
            {
				return Redirect("/Identity/Account/AccessDenied"); ;
            }

            var model = new DBPetrolModelVM { vehicleId = vehicleIDRoute };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Petrol( DBPetrolModelVM dBPetrolModelVM)
        {
            if (await _repositorySecurity.CheckUser(dBPetrolModelVM.vehicleId, User) == null)
            {
				return Redirect("/Identity/Account/AccessDenied");
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
                await _repositoryPetrol.AddAsync(dbVM);
                //Musí být abych zpátky měl ID daného vozidla, jinak bych dostal Unauthorized
                return RedirectToAction("Index", new { vehicleIDRoute = dBPetrolModelVM.vehicleId });
            }
            return View(dBPetrolModelVM);
        }
        public async Task<IActionResult> Vignette(int vehicleIDRoute)
        {
            if(await _repositorySecurity.CheckUser(vehicleIDRoute, User) == null)
            {
                Console.WriteLine($"{vehicleIDRoute} {User}");
                return Redirect("/Identity/Account/AccessDenied");
            }
            ViewBag.Countries = _countryService.GetCountries();
            var model = new DBVignetteModelVM { vehicleId = vehicleIDRoute };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Vignette(DBVignetteModelVM dBVignetteModelVM)
        {
            if (await _repositorySecurity.CheckUser(dBVignetteModelVM.vehicleId, User) == null)
            {
                return Redirect("/Identity/Account/AccessDenied");
            }
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
