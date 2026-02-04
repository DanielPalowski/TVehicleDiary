using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Constants;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers.Repairs
{
    public class UpgradeVehicleController : Controller, IFileSizeMax
    {
        private readonly IUpgradeVehicleService _upgradeVehicleService;
        private readonly IMapper _mapper;
        private readonly IRepositoryCrud<DBUpgradeVehicleModel> _upgradeRepository;

        public UpgradeVehicleController(IUpgradeVehicleService upgradeVehicleService, IMapper mapper, IRepositoryCrud<DBUpgradeVehicleModel> upgradeRepository)
        {
            _upgradeVehicleService = upgradeVehicleService;
            _mapper = mapper;
            _upgradeRepository = upgradeRepository;
        }

        public async Task<IActionResult> Index([FromQuery] Guid vehicleIDRoute)
        {
            var upgrade = await _upgradeVehicleService.GettingRepairViewAsync(vehicleIDRoute);

            var upgradeViews = _mapper.Map<IEnumerable<DBUpgradeVehicleModelVM>>(upgrade);
            var model = new DBUpgradeVehicleModelVM
            {
                VehicleId = vehicleIDRoute,
                RepairViews = upgradeViews
            };

            return View(model);
        }


        public async Task<IActionResult> Create([FromQuery] Guid vehicleIDRoute)
        {

            var model = new DBUpgradeVehicleModelVM { VehicleId = vehicleIDRoute };
            return View(model);
        }


        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = IFileSizeMax.MAX_FILE_SIZE)]
        public async Task<IActionResult> Create(DBUpgradeVehicleModelVM model)
        {
            //Backend method to not be adding beyond 25 upgrades.
            /*var MaxRapairCount = await _upgradeVehicleService.CountingAsync(model.VehicleId);
            if (MaxRapairCount >= 25)
            {
                ModelState.AddModelError("MaxRepair", "You have reached the maximum limit of 25 repair");
            }*/


            if (model.Upload != null && model.Upload.Length > IFileSizeMax.MAX_FILE_SIZE)
            {
                ModelState.AddModelError("Upload", $"File size exceeds the maximum limit of 5 MB.");
            }


            if (ModelState.IsValid)
            {
                var upgradeDto = _mapper.Map<UpgradeVehicleDto>(model);
                await _upgradeVehicleService.AddingRepairAsync(upgradeDto);
                return RedirectToAction("Index", new { vehicleIDRoute = model.VehicleId });
            }

            var repairs = await _upgradeVehicleService.GettingRepairViewAsync(model.VehicleId);
            model.RepairViews = _mapper.Map<IEnumerable<DBUpgradeVehicleModelVM>>(repairs);

            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _upgradeVehicleService.RemovingAsync(id);
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> Download(Guid id)
        {
            try
            {
                var fileResult = await _upgradeVehicleService.DownloadingAsync(id);
                return fileResult;
            }
            catch (Exception ex)
            {

                TempData["ErrorMessage"] = "File not found or error downloading file.";

                var currentVehicleId = Request.Query["vehicleIDRoute"];
                if (!string.IsNullOrEmpty(currentVehicleId))
                {
                    return RedirectToAction("Index", new { vehicleIDRoute = currentVehicleId });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}
