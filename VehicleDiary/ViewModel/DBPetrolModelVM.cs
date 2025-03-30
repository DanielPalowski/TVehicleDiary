using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleDiary.Models;

namespace VehicleDiary.ViewModel
{
    public class DBPetrolModelVM
    {
        [Required]
        public string PetrolDate { get; set; }
        [Required]
        public string PetrolType { get; set; }
        public int? PetrolMileage { get; set; }
        [Required]
        public int PetrolPrice { get; set; }
        [Required]
        public int PetrolAmount { get; set; }
        [Required]
        public Guid vehicleId { get; set; }
    }
}
