using System.ComponentModel.DataAnnotations;

namespace VehicleDiary.Web.ViewModels
{
    public class DBRepairVehicleModelVM
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string RepairVCategory { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string RepairVType { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string RepairVName { get; set; }

        [Required]
        [Display(Name = "Part")]
        public string RepairVPart { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime RepairVWhen { get; set; }

        [Required]
        [Display(Name = "Price")]
        public float RepairVPrice { get; set; }

        [Display(Name = "Notes")]
        public string? ReapairVNotes { get; set; }

        [Display(Name = "Technician")]
        public string RepairVTechnician { get; set; }

        [Required]
        public Guid VehicleId { get; set; }


        public IEnumerable<DBRepairVehicleModelVM>? RepairViews { get; set; }
    }

}

