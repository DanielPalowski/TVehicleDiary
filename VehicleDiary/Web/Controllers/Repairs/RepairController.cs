using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Constants;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Web.Controllers.Repairs
{
    [Authorize]
    public class RepairController : Controller
    {
        public readonly IRepositoryCrud<DBRepairsModel> _repositoryCrudRepair;
        public readonly IRepositoryViews<DBRepairsModel> _repositoryViews;
        public readonly IRepositoryVehicle _repositoryVehicle;
        public readonly IRepairService _repairService;
        public readonly IMapper _mapper;

        public RepairController(IRepositoryCrud<DBRepairsModel> repository,
            IRepositoryVehicle repositoryVehicle,
            IRepositoryViews<DBRepairsModel> repositoryViews,
            IRepairService repairService,
            IMapper mapper)

        {
            _repositoryCrudRepair = repository;
            _repositoryVehicle = repositoryVehicle;
            _repositoryViews = repositoryViews;
            _repairService = repairService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index([FromQuery] Guid vehicleIDRoute)
        {
            var moneyCount = await _repairService.TotalCostAsync(vehicleIDRoute);

            var entity = await _repairService.ShowingRepairsAsync(vehicleIDRoute);
            var repairs = _mapper.Map<IEnumerable<DBRepairModelVM>>(entity);


            var ViewModelDB = new DBRepairModelVM
            {
                vehicleId = vehicleIDRoute,
                RepairsView = repairs,
                TotalRepairCost = moneyCount
            };

            return View(ViewModelDB);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repairService.RemovingAsync(id);
            return Ok();
        }
        public async Task<IActionResult> Create([FromQuery] Guid vehicleIDRoute)
        {

            var model = new DBRepairModelVM { vehicleId = vehicleIDRoute };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DBRepairModelVM dBRepairModelVM)
        {

            if (ModelState.IsValid)
            {
                var repairs = _mapper.Map<RepairDto>(dBRepairModelVM);
                await _repairService.AddingRepairAsync(repairs);
                return RedirectToAction("Index", new { vehicleIDRoute = dBRepairModelVM.vehicleId });
            }
            return View();
        }

    }
}
