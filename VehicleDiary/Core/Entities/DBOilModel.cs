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
        public float OilAmount { get; set; }
        [Required]
        public DateTime OilDate { get; set; }
        [Required]
        public string OilType { get; set; }
        [Required]
        public int OilMileage { get; set; }
        [Required]
        public float OilPrice { get; set; }
        public string? OilDescription { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public Guid VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public DBVehicleModel Vehicle { get; set; }
    }
}
