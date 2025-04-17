using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VehicleDiary.Web.ViewModels
{
    public class DBPetrolModelVM
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime PetrolDate { get; set; }
        [Required]
        public string PetrolType { get; set; }
        public int? PetrolMileage { get; set; }
        [Required]
        public int PetrolPrice { get; set; }
        [Required]
        public int PetrolAmount { get; set; }
        [Required]
        public Guid vehicleId { get; set; }
        public IEnumerable<DBPetrolModelVM>? PetrolViews { get; set;}
    }
}
