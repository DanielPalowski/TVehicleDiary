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
    public class OilController : Controller
    {
        private readonly IOilService _oilService;
        private readonly IMapper _mapper;
        public OilController( IOilService oilService, IMapper mapper)
        {
            _mapper = mapper;
            _oilService = oilService;
        }
        public async Task<IActionResult> Oil([FromQuery] Guid vehicleIDRoute)
        {
            var entries = await _oilService.GettingOiLViewAsync(vehicleIDRoute);
            var entity = _mapper.Map<IEnumerable<DBOilModelVM>>(entries);
            var model = new DBOilModelVM
            {
                VehicleId = vehicleIDRoute,
                OilViews = entity
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Oil(DBOilModelVM dBOilModelVM)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<OilDto>(dBOilModelVM);
                await _oilService.AddingOilAsync(entity);
                return RedirectToAction("Index","CarUsage", new { vehicleIDRoute = dBOilModelVM.VehicleId });

            }
            return View(dBOilModelVM);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _oilService.RemovingAsync(Id);
            return Ok();
        }
    }
}
