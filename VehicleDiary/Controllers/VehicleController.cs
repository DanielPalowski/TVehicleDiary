using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Models;
using VehicleDiary.Repository;
using VehicleDiary.ViewModel;

namespace VehicleDiary.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IRepositoryCrud<DBVehicleModel> _repository;
        private readonly UserManager<IdentityUser> _userManager;
        public VehicleController(IRepositoryCrud<DBVehicleModel> repository, UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _repository.GetDBByIDForUserAsync(User);
            return View(user);
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
                var DBVehicle = new DBVehicleModel
                {
                    Name = DBVehicleVM.Name,
                    Model = DBVehicleVM.Model,
                    MadeYear = DBVehicleVM.MadeYear,
                    VIN = DBVehicleVM.VIN,
                    License_plate = DBVehicleVM.License_plate,
                    Power = DBVehicleVM.Power,
                    Insurence = DBVehicleVM.Insurence,
                    Description = DBVehicleVM.Description,
                    UserId = _userManager.GetUserId(User)
                    
                };
                await _repository.AddAsync(DBVehicle);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
