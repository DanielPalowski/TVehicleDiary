using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleDiary.Core.Interfaces;

namespace VehicleDiary.Core.Entities
{
    public class DBTiresModel : IVehicleEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public float TirePrice { get; set; }
        [Required]
        public int TireAmount { get; set; }
        [Required]
        public string TireBrand { get; set; }
        [Required]
        public int TireType { get; set; }
        [Required]
        public string TireSize { get; set; }
        [Required]
        public DateTime TireDate { get; set; }
        public float? TireChangedPrice { get; set; }
        public string? TireShopWhereBought { get; set; }
        public string? TireDescription { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public Guid VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public DBVehicleModel Vehicle { get; set; }

    }
}
