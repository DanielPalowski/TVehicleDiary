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

        public readonly IRepairHUBCount _repairHUBCount;

        public RepairController(IRepairHUBCount repairHUBCount)

        {
            _repairHUBCount = repairHUBCount;
        }
        public async Task<IActionResult> Index([FromQuery] Guid vehicleIDRoute)
        {
            var moneyCountRepair = await _repairHUBCount.TotalCostRepairAsync(vehicleIDRoute);
            var moneyCountUpgrade = await _repairHUBCount.TotalCostUpgradeAsync(vehicleIDRoute);
            var moneyCountDiagnostic = await _repairHUBCount.TotalCostDiagnosticAsync(vehicleIDRoute);



            var ViewModelDB = new DBRepairModelVM
            {
                vehicleId = vehicleIDRoute,
                TotalRepairCost = moneyCountRepair,
                TotalDiagnosticCost = moneyCountDiagnostic,
                TotalUpgradeCost = moneyCountUpgrade

            };

            return View(ViewModelDB);
        }

    }
}
