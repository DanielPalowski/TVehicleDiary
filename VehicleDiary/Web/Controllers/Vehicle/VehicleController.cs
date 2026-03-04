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
        private readonly AppDbContext _context;
        private readonly IEmailSender _emailSender;
        public VehicleController(UserManager<IdentityUser> userManager, IVehicleService vehicleService, IMapper mapper, AppDbContext context, IEmailSender emailSender)
        {
            _userManager = userManager;
            _vehicleService = vehicleService;
            _mapper = mapper;
            _context = context;
            _emailSender = emailSender;

        }
        public async Task<IActionResult> Index()
        {


            var user = _userManager.GetUserId(User);

            // Get vehicles WITH RepairCost filled
            var vehicles = await _vehicleService.GetVehiclesWithTotalCostAsync(user);
            var mailto = "daniel.palowski@email.cz";
            var subject = "Hello world test";
            var message = "Hello world testicek";


            var vehiclesSTK = _context.DBVehiclesSet
                .Where(find => !string.IsNullOrEmpty(find.STK) &&
                !find.EmailSendDate.HasValue)
                .ToList();
            if (vehiclesSTK.Count > 0)
            {
                foreach (var car in vehiclesSTK)
                {
                    string stringCar = car.STK;
                    string strippedYearCar = stringCar.Split('-')[0];
                    string strippedMonthCar = stringCar.Split('-')[1];
                    int carYear = int.Parse(strippedYearCar);
                    int carMonth = int.Parse(strippedMonthCar);
                    if ((DateTime.Now.Year == carYear && carMonth - 1 == DateTime.Now.Month) || (carMonth == 1 && carYear - 1 == DateTime.Now.Year))
                    {
                        car.EmailSendDate = DateTime.Now;
                        await _emailSender.SendEmailAsync(mailto, subject, message);
                    }
                    _context.SaveChanges();

                }
            }

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
