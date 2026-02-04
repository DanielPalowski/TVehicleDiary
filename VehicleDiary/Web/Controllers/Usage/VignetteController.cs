using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Application.Services;
using VehicleDiary.Application.Services.MapperService;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers.Usage
{
    public class VignetteController : Controller
    {
        private readonly CountryService _countryService;
        private readonly IVignetteService _vignetteService;
        private readonly IMapper _mapper;
        public VignetteController(CountryService countryService, IVignetteService vignetteService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
            _vignetteService = vignetteService;
        }
        public async Task<IActionResult> Vignette([FromQuery] Guid vehicleIDRoute)
        {
            var entity = await _vignetteService.GettingVignetteAsync(vehicleIDRoute);
            var repairs = _mapper.Map<IEnumerable<DBVignetteModelVM>>(entity);

            ViewBag.Countries = _countryService.GetCountries();
            var model = new DBVignetteModelVM
            {
                vehicleId = vehicleIDRoute,
                VignetteView = repairs
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Vignette(DBVignetteModelVM dBVignetteModelVM)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<VignetteDto>(dBVignetteModelVM);
                await _vignetteService.AddingVignetteAsync(entity);
                return RedirectToAction("Index","CarUsage", new { vehicleIDRoute = dBVignetteModelVM.vehicleId });

            }
            return View(dBVignetteModelVM);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _vignetteService.RemovingAsync(Id);
            return Ok();
        }
    }
}
