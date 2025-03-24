using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleDiary.Interfaces;
using VehicleDiary.Migrations;

namespace VehicleDiary.Models
{
    public class DBPetrolModel : IVehicleEntity
    {
        public int id {  get; set; }
        [Required]
        public string PetrolDate { get; set; }
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
        public int VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public DBVehicleModel Vehicle { get; set; }
    }
}
