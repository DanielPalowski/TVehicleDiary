using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers
{
    public class RepairVehicleController : Controller
    {
        private readonly IRepairVehicleService _repairVehicleService;
        private readonly IMapper _mapper;

        public RepairVehicleController(IRepairVehicleService repairVehicleService, IMapper mapper)
        {
            _repairVehicleService = repairVehicleService;
            _mapper = mapper;
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
                Debug.WriteLine($"RepairVCategory: {model.RepairVCategory}");
                Debug.WriteLine($"RepairVType: {model.RepairVType}");
                Debug.WriteLine($"RepairVName: {model.RepairVName}");
                Debug.WriteLine($"RepairVPart: {model.RepairVPart}");
                Debug.WriteLine($"RepairVWhen: {model.RepairVWhen}");
                Debug.WriteLine($"RepairVPrice: {model.RepairVPrice}");
                Debug.WriteLine($"RepairVNotes: {model.ReapairVNotes}");
                Debug.WriteLine($"RepairVTechnician: {model.RepairVTechnician}");
                Debug.WriteLine($"VehicleId: {model.VehicleId}");
                var repairDto = _mapper.Map<RepairVehicleDto>(model);
                await _repairVehicleService.AddingRepairAsync(repairDto);
                return RedirectToAction("Index", new { vehicleIDRoute = model.VehicleId });
            }

                    // If validation fails, reload the repairs
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
    }
}
