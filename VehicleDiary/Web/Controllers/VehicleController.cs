using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IVehicleService _vehicleService;
        public VehicleController(UserManager<IdentityUser> userManager, IVehicleService vehicleService, IMapper mapper)
        {
            _userManager = userManager;
            _vehicleService = vehicleService;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            var user = _userManager.GetUserId(User);
            var vehicle = await _vehicleService.GettingVehiclesAsync(user);
            var returnView = _mapper.Map<IEnumerable<DBVehicleViewVM>>(vehicle);
            return View(returnView);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete (Guid id)
        {
            await _vehicleService.DeleteVehicleAsync(id);
            return Ok();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DBVehicleModelVM DBVehicleVM)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<VehicleDto>(DBVehicleVM); 
                dto.UserId = _userManager.GetUserId(User); 
                await _vehicleService.AddVehicleAsync(dto);
                return RedirectToAction("Index");
            }
            return View(DBVehicleVM);
        }
    }
}
