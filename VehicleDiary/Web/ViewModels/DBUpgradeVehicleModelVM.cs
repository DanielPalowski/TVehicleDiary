using System.ComponentModel.DataAnnotations;

namespace VehicleDiary.Web.ViewModels
{
    public class DBUpgradeVehicleModelVM
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string UpgradeVCategory { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string UpgradeVType { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string UpgradeVName { get; set; }
        [Required]
        [MaxLength(100)]
        public string UpgradeVStatus { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime UpgradeVWhen { get; set; }

        [Required]
        [Display(Name = "Mileage")]
        public int UpgradeVMileage { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float UpgradeVPrice { get; set; }

        [Display(Name = "Notes")]
        public string? UpgradeVNotes { get; set; }

        [Display(Name = "Technician")]
        public string? UpgradeVTechnician { get; set; }

        [Display(Name = "Part Brand")]
        public string? UpgradeVPartBrand { get; set; }
        [Display(Name = "Part Code")]
        public string? UpgradeVPartCode { get; set; }



        [Required]
        public Guid VehicleId { get; set; }


        public IEnumerable<DBUpgradeVehicleModelVM>? RepairViews { get; set; }

        public IFormFile? Upload { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public DateTime? UploadTime { get; set; }
        public IEnumerable<DBUpgradeVehicleModelVM>? Files { get; set; }
    }
}
