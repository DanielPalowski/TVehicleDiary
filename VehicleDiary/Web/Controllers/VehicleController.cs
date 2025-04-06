using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IRepositoryCrud<DBVehicleModel> _repository;
        private readonly IMapper _mapper;
        private readonly IRepositoryVehicle _repositoryVehicle;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IVehicleService _vehicleService;
        public VehicleController(IRepositoryCrud<DBVehicleModel> repository, UserManager<IdentityUser> userManager, IRepositoryVehicle repositoryVehicle, IVehicleService vehicleService, IMapper mapper)
        {
            _repository = repository;
            _userManager = userManager;
            _repositoryVehicle = repositoryVehicle;
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
