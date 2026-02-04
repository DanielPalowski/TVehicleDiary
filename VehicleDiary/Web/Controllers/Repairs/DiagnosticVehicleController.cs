using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Application.Services.MapperService;
using VehicleDiary.Core.Constants;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers.Repairs
{
    public class DiagnosticVehicleController : Controller, IFileSizeMax
    {
        private readonly IDiagnosticVehicleService _diagnosticVehicleService;
        private readonly IMapper _mapper;
        private readonly IRepositoryCrud<DBDiagnosticVehicleModel> _diagnosticRepository;

        public DiagnosticVehicleController(IDiagnosticVehicleService DiagnosticVehicleService, IMapper mapper, IRepositoryCrud<DBDiagnosticVehicleModel> DiagnosticRepository)
        {
            _diagnosticVehicleService = DiagnosticVehicleService;
            _mapper = mapper;
            _diagnosticRepository = DiagnosticRepository;
        }

        public async Task<IActionResult> Index([FromQuery] Guid vehicleIDRoute)
        {
            var diagnostic = await _diagnosticVehicleService.GettingRepairViewAsync(vehicleIDRoute);

            var diagnosticViews = _mapper.Map<IEnumerable<DBDiagnosticVehicleModelVM>>(diagnostic);
            var model = new DBDiagnosticVehicleModelVM
            {
                VehicleId = vehicleIDRoute,
                RepairViews = diagnosticViews
            };

            return View(model);
        }


        public async Task<IActionResult> Create([FromQuery] Guid vehicleIDRoute)
        {

            var model = new DBDiagnosticVehicleModelVM { VehicleId = vehicleIDRoute };
            return View(model);
        }


        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = IFileSizeMax.MAX_FILE_SIZE)]
        public async Task<IActionResult> Create(DBDiagnosticVehicleModelVM model)
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
                var diagnosticDto = _mapper.Map<DiagnosticVehicleDto>(model);
                await _diagnosticVehicleService.AddingRepairAsync(diagnosticDto);
                return RedirectToAction("Index", new { vehicleIDRoute = model.VehicleId });
            }

            var repairs = await _diagnosticVehicleService.GettingRepairViewAsync(model.VehicleId);
            model.RepairViews = _mapper.Map<IEnumerable<DBDiagnosticVehicleModelVM>>(repairs);

            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _diagnosticVehicleService.RemovingAsync(id);
            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> Download(Guid id)
        {
            try
            {
                var fileResult = await _diagnosticVehicleService.DownloadingAsync(id);
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
