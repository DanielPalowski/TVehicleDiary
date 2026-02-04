using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Application.Services.MapperService;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers.Usage
{
    public class TireController : Controller

    {
        private readonly IMapper _mapper;
        private readonly ITireService _service;
        public TireController(IMapper mapper, ITireService service)
        {
            _mapper = mapper;
            _service = service;
        }
        public async Task<IActionResult> Tires([FromQuery] Guid vehicleIDRoute)
        {
            var entity = await _service.GetAllTiresAsync(vehicleIDRoute);
            var map = _mapper.Map<IEnumerable<DBTiresModelVM>>(entity);
            var model = new DBTiresModelVM {
                VehicleId = vehicleIDRoute,
                TireViews = map
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Tires(DBTiresModelVM dBTiresModelVM)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<TireDto>(dBTiresModelVM);
                await _service.AddingNewTiresAsync(entity);
                return RedirectToAction("Index", "CarUsage", new { vehicleIdRoute = dBTiresModelVM.VehicleId });
            }
            return View(dBTiresModelVM);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _service.RemovingAsync(Id);
            return Ok();
        }
    }
}
