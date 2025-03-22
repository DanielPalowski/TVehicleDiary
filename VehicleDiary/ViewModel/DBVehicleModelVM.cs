using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehicleDiary.ViewModel
{
    public class DBVehicleModelVM
    {
        [Required(ErrorMessage = "Brand is required !")]
        [MaxLength(30),MinLength(2), ]
        public string Name { get; set; }

        [Required(ErrorMessage = "Model is required !")]
        [MaxLength(30), MinLength(2)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Description is required !")]
        [MaxLength(300), MinLength(2)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Year is required !")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Must be 4 digits")]
        public int MadeYear { get; set; }

        [Required(ErrorMessage = "License plate is required !")]
        [MaxLength(12), MinLength(2)]
        public string? License_plate { get; set; }

        [Required(ErrorMessage = "VIN is required !")]
        [MaxLength(60), MinLength(2)]
        public string? VIN { get; set; }

        [Required(ErrorMessage = "Horsepower is required !")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Must be 6 digits")]
        public int Power { get; set; }

        [Required(ErrorMessage = "Insurence is required !")]
        [MaxLength(30), MinLength(2)]
        public string? Insurence { get; set; }


    }
}
