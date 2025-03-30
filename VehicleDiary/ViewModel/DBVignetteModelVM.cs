using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleDiary.Models;

namespace VehicleDiary.ViewModel
{
    public class DBVignetteModelVM
    {
        [Required]
        public string Country { get; set; }
        [Required]
        [Display(Name = "Valid From")]
        public DateTime ValidFrom { get; set; }
        [Required]
        [Display(Name = "Valid To")]
        public DateTime ValidTo { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public Guid vehicleId { get; set; }

    }
}
