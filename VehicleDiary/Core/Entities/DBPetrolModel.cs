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
        public DateTime PetrolDate { get; set; }
        [Required]
        public string PetrolType { get; set; }
        public int? PetrolMileage { get; set; }
        [Required]
        public float PetrolPrice { get; set; }
        [Required]
        public float PetrolAmount { get; set; }
        public float? PetrolPricePerLiter { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public Guid VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public DBVehicleModel Vehicle { get; set; }
    }
}
