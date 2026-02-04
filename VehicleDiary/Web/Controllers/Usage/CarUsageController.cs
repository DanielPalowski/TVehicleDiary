using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Application.Services;
using VehicleDiary.Application.Services.MapperService;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers.Usage
{
    [Authorize]
    public class CarUsageController : Controller
    {
        private readonly ICarUsageService _carUsageService;
        private readonly IMapper _mapper;
        public CarUsageController(ICarUsageService carUsageService,
            IMapper mapper)

        {
            _mapper = mapper;
            _carUsageService = carUsageService;
        }
        public async Task<IActionResult> Index([FromQuery] Guid vehicleIDRoute)
        {
            var Tiredto = await _carUsageService.LatestTireUsageAsync(vehicleIDRoute);
            var Tireentity = _mapper.Map<DBCarUsageOverViewVM>(Tiredto);

            var Petroldto = await _carUsageService.LatestPetrolUsageAsync(vehicleIDRoute);
            var Petrolentity = _mapper.Map<DBCarUsageOverViewVM>(Petroldto);

            var Oildto = await _carUsageService.LatestOilUsageAsync(vehicleIDRoute);
            var Oilentity = _mapper.Map<DBCarUsageOverViewVM>(Oildto);

            var Vignettedto = await _carUsageService.LatestVignetteUsageAsync(vehicleIDRoute);
            var Vignetteentity = _mapper.Map<DBCarUsageOverViewVM>(Vignettedto);


            var ViewModelDB = new DBCarUsageOverViewVM
            {
                VehicleID = vehicleIDRoute,
                LatestTireUsage = Tiredto,
                LatestOilUsage = Oildto,
                LatestPetrolUsage = Petroldto,
                LatestVignetteUsage = Vignettedto
            };


            return View(ViewModelDB);
        }
    }
}
