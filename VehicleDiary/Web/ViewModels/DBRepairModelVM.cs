using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VehicleDiary.Core.Entities;
using VehicleDiary.Application.DTOs;

namespace VehicleDiary.Web.ViewModels
{
    public class DBRepairModelVM
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter what repair you have done !")]
        [MaxLength(40), MinLength(2),]
        public string RepairType { get; set; }
        [MaxLength(150), MinLength(2),]
        public string? RepairDescription { get; set; }
        [Required(ErrorMessage = "Please enter the cost of this repair !")]
        public float RepairCost { get; set; }
        public DateTime RepairMade { get; set; }
        [Required]
        public int RepairMileage { get; set; }
        [Required]
        public Guid vehicleId { get; set; }
        public IEnumerable<DBRepairModelVM>? RepairsView { get; set; }
        public float TotalRepairCost { get; set; }
        public float TotalUpgradeCost { get; set; }
        public float TotalDiagnosticCost { get; set; }

    }
}
