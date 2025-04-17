using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using VehicleDiary.Core.Interfaces;

namespace VehicleDiary.Core.Entities
{
    public class DBRepairsModel : IVehicleEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string RepairType { get; set; }
        public string? RepairDescription { get; set; }
        [Required]
        public float RepairCost { get; set; }
        [Required]
        public DateTime RepairMade { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public int RepairMileage { get; set; }
        [Required]
        public Guid VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public DBVehicleModel Vehicle { get; set; }

    }
}
