using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Application.Services.MapperService;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers.Usage
{
    public class PetrolController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPetrolService _petrolService;
        public PetrolController(IMapper mapper, IPetrolService petrolService)
        {
            _mapper = mapper;
            _petrolService = petrolService;
        }
        public async Task<IActionResult> Petrol([FromQuery] Guid vehicleIDRoute)
        {
            var entity = await _petrolService.GetAllPetrolModelsAsync(vehicleIDRoute);
            var entry = _mapper.Map<IEnumerable<DBPetrolModelVM>>(entity);
            var model = new DBPetrolModelVM
            { 
                vehicleId = vehicleIDRoute,
                PetrolViews = entry
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Petrol(DBPetrolModelVM dBPetrolModelVM)
        {
            if (ModelState.IsValid)
            {
               var entity = _mapper.Map<PetrolDto>(dBPetrolModelVM);
               await _petrolService.AddingPetrolAsync(entity);
                return RedirectToAction("Index", "CarUsage", new { vehicleIDRoute = dBPetrolModelVM.vehicleId });
            }
            return View(dBPetrolModelVM);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await _petrolService.RemovingAsync(Id);
            return Ok();
        }

    }
}
