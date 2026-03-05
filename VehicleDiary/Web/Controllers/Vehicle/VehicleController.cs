using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Infrastructure.Data;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers.Vehicle
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

            // Get vehicles WITH RepairCost filled
            var vehicles = await _vehicleService.GetVehiclesWithTotalCostAsync(user);

            await _vehicleService.SendingEmailAsync(User);
   

            // Map THAT list
            var returnView = _mapper.Map<IEnumerable<DBVehicleViewVM>>(vehicles);

            return View(returnView);

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
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
            var userId = _userManager.GetUserId(User);
            var userVehicleCount = await _vehicleService.CountingVehiclesAsync(userId);
            if (userVehicleCount >= 3)
            {
                ModelState.AddModelError(string.Empty, "You cant add more than 3 vehicles.");
                return View(DBVehicleVM);
            }

            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<VehicleDto>(DBVehicleVM);
                dto.UserId = _userManager.GetUserId(User);
                await _vehicleService.AddVehicleAsync(dto);
                return RedirectToAction("Index");
            }
            return View(DBVehicleVM);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var userId = _userManager.GetUserId(User);
            var vehicleDto = await _vehicleService.GetVehicleByIdAndUserAsync(id, userId);

            if (vehicleDto == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<DBVehicleModelVM>(vehicleDto);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, DBVehicleModelVM vehicleVM)
        {
            if (id != vehicleVM.Id)
            {
                return BadRequest();
            }

            var userId = _userManager.GetUserId(User);
            var existingVehicle = await _vehicleService.GetVehicleByIdAndUserAsync(id, userId);

            if (existingVehicle == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<VehicleDto>(vehicleVM);
                dto.UserId = userId;
                await _vehicleService.EditVehicleAsync(dto);
                return RedirectToAction("Index");
            }

            return View(vehicleVM);
        }

    }
}
