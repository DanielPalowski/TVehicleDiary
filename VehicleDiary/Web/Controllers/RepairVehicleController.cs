using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers
{
    public class RepairVehicleController : Controller
    {
        private readonly IRepairVehicleService _repairVehicleService;
        private readonly IMapper _mapper;
        private readonly IRepositoryCrud<DBRepairVehicleModel> _repairRepository;

        public RepairVehicleController(IRepairVehicleService repairVehicleService, IMapper mapper, IRepositoryCrud<DBRepairVehicleModel> repairRepository)
        {
            _repairVehicleService = repairVehicleService;
            _mapper = mapper;
            _repairRepository = repairRepository;
        }

        public async Task<IActionResult> Index([FromQuery] Guid vehicleIDRoute)
        {
            var repairs = await _repairVehicleService.GettingRepairViewAsync(vehicleIDRoute);
            var repairViews = _mapper.Map<IEnumerable<DBRepairVehicleModelVM>>(repairs);
            var model = new DBRepairVehicleModelVM
            {
                VehicleId = vehicleIDRoute,
                RepairViews = repairViews
            };

            return View(model);
        }
        public async Task<IActionResult> Create([FromQuery] Guid vehicleIDRoute)
        {

            var model = new DBRepairVehicleModelVM { VehicleId = vehicleIDRoute };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DBRepairVehicleModelVM model)
        {
            if (ModelState.IsValid)
            {
                var repairDto = _mapper.Map<RepairVehicleDto>(model);
                await _repairVehicleService.AddingRepairAsync(repairDto);
                return RedirectToAction("Index", new { vehicleIDRoute = model.VehicleId });
            }
           
            var repairs = await _repairVehicleService.GettingRepairViewAsync(model.VehicleId);
            model.RepairViews = _mapper.Map<IEnumerable<DBRepairVehicleModelVM>>(repairs);

            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repairVehicleService.RemovingAsync(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Download(Guid id)
        {
            try
            {
                var fileResult = await _repairVehicleService.DownloadingAsync(id);
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
