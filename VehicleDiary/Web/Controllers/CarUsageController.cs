using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol;
using VehicleDiary.Application.Services;
using VehicleDiary.Application.Services.MapperService;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers
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
        private readonly IRepositoryCarUsage _repositoryCarUsage;
        private readonly IVignetteService _vignetteService;
        private readonly IMapper _mapper;
        public CarUsageController(IRepositoryCrud<DBPetrolModel> repository,
            IRepositoryViews<DBPetrolModel> repositoryView,
            CountryService countryService,
            IRepositoryCrud<DBVignetteModel> repositoryVignette,
            IRepositoryCrud<DBOilModel> repositoryOil,
            IRepositoryCrud<DBTiresModel> repositoryTires,
            IRepositoryCarUsage repositoryCarUsage,
			IVignetteService vignetteService,
            IMapper mapper)

        {
            _repositoryPetrol = repository;
            _repositoryView = repositoryView;
            _countryService = countryService;
            _repositoryVignette = repositoryVignette;
            _repositoryOil = repositoryOil;
            _repositoryTires = repositoryTires;
            _repositoryCarUsage = repositoryCarUsage;
            _vignetteService = vignetteService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index([FromQuery] Guid vehicleIDRoute)
        {
            var CarUsage = await _repositoryView.GetDBByVehicle(vehicleIDRoute);
            var latestVignette = await _repositoryCarUsage.GettingLatestVignetteAsync(vehicleIDRoute);


            var ViewModelDB = new DBCarUsageOverViewVM
            {
                VehicleId = vehicleIDRoute,
                LatestVignetteCountry = latestVignette?.VignetteCountry,
                LatestVignetteValidFrom = latestVignette?.VignetteValidFrom,
                LatestVignetteValidTo = latestVignette?.VignetteValidTo,
                LatestVignettePrice = latestVignette?.VignettePrice
            };


            return View(ViewModelDB);
        }


        //-----------------Tires-------------
        public async Task<IActionResult> Tires([FromQuery] Guid vehicleIDRoute)
        {
            var model = new DBTiresModelVM { VehicleId = vehicleIDRoute };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Tires(DBTiresModelVM dBTiresModelVM)
        {
            if (ModelState.IsValid)
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
                return RedirectToAction("Index", new { vehicleIdRoute = dBTiresModelVM.VehicleId });
            }
            return View(dBTiresModelVM);
        }
    }
}
