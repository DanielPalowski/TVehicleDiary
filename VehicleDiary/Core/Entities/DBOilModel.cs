using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleDiary.Core.Interfaces;

namespace VehicleDiary.Core.Entities
{
    public class DBOilModel : IVehicleEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public float OilAmount { get; set; }
        [Required]
        [MaxLength(100)]
        public DateTime OilDate { get; set; }
        [Required]
        [MaxLength(100)]
        public string OilType { get; set; }
        [Required]
        [MaxLength(100)]
        public int OilMileage { get; set; }
        [Required]
        [MaxLength(100)]
        public float OilPrice { get; set; }
        [MaxLength(500)]
        public string? OilDescription { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public Guid VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public DBVehicleModel Vehicle { get; set; }
    }
}
