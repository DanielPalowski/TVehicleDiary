using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleDiary.Core.Interfaces;

namespace VehicleDiary.Core.Entities
{
    public class DBPetrolModel : IVehicleEntity
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [MaxLength(100)]
        public DateTime PetrolDate { get; set; }
        [Required]
        [MaxLength(100)]
        public string PetrolType { get; set; }
        [MaxLength(100)]
        public int? PetrolMileage { get; set; }
        [Required]
        [MaxLength(100)]
        public float PetrolPrice { get; set; }
        [Required]
        [MaxLength(100)]
        public float PetrolAmount { get; set; }
        [MaxLength(100)]
        public float? PetrolPricePerLiter { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public Guid VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public DBVehicleModel Vehicle { get; set; }
    }
}
