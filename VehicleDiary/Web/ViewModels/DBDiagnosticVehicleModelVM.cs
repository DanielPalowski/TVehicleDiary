using System.ComponentModel.DataAnnotations;

namespace VehicleDiary.Web.ViewModels
{
    public class DBDiagnosticVehicleModelVM
    {
        public Guid ID { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string DiagnosticVCategory { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string DiagnosticVType { get; set; }
        [Display(Name = "Error Type")]
        public string? DiagnosticVErrorType { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string DiagnosticVName { get; set; }
        [Display(Name = "Error Code")]
        public string? DiagnosticVErrorCode { get; set; }
        [Display(Name = "Error Note")]
        public string? DiagnosticVErrorDis { get; set; }
        [Display(Name = "Diagnostic Tool")]
        public string? DiagnosticVDiagnosticType { get; set; }
        [Display(Name = "Mileage")]
        public int? DiagnosticVMileage { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime DiagnosticVWhen { get; set; }
        [Display(Name = "Price")]
        public float? DiagnosticVPrice { get; set; }
        [Display(Name = "Notes")]
        public string? DiagnosticVNotes { get; set; }
        [Display(Name = "Technician")]
        public string? UpgradeVTechnician { get; set; }

        public IEnumerable<DBDiagnosticVehicleModelVM>? RepairViews { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public byte[]? Data { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public IFormFile Upload { get; set; }


        [Required]
        public Guid VehicleId { get; set; }
    }
}
