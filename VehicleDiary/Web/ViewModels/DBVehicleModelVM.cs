using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleDiary.Web.ViewModels
{
    public class DBVehicleModelVM
    {
        [Required(ErrorMessage = "Brand is required !")]
        [MaxLength(30), MinLength(2),]
        public string Name { get; set; }

        [Required(ErrorMessage = "Model is required !")]
        [MaxLength(30), MinLength(2)]
        public string Model { get; set; }

        [MaxLength(300), MinLength(2)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Year is required !")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Must be 4 digits")]
        [Range(1900,2100)]
        public int MadeYear { get; set; }

        [Required(ErrorMessage = "License plate is required !")]
        [MaxLength(12), MinLength(2)]
        public string? License_plate { get; set; }

        [Required(ErrorMessage = "VIN is required !")]
        [MaxLength(20), MinLength(2)]
        public string? VIN { get; set; }

        [Required(ErrorMessage = "Horsepower is required !")]
        public int Power { get; set; }

        [Required(ErrorMessage = "Insurence is required !")]
        [MaxLength(30), MinLength(2)]
        public string? Insurence { get; set; }
        public DateTime? Bought { get; set; }


    }
}
