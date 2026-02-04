using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleDiary.Core.Constants;
using VehicleDiary.Core.Interfaces;

namespace VehicleDiary.Core.Entities
{
    public class DBDiagnosticVehicleModel : IVehicleEntity, IHasFile
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string DiagnosticVCategory { get; set; }
        [Required]
        [MaxLength(100)]
        public string DiagnosticVType { get; set; }
        [MaxLength(100)]
        public string? DiagnosticVErrorType { get; set; }
        [Required]
        [MaxLength(100)]
        public string DiagnosticVName { get; set; }



        [Required]
        [MaxLength(100)]
        public string? DiagnosticVErrorCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string? DiagnosticVErrorDis { get; set; }
        [Required]
        [MaxLength(100)]
        public string? DiagnosticVDiagnosticType { get; set; }


        [Required]
        [MaxLength(9)]
        public int? DiagnosticVMileage { get; set; }

        [Required]
        public DateTime DiagnosticVWhen { get; set; }



        [Required]
        [MaxLength(20)]
        public float? DiagnosticVPrice { get; set; }

        public string? DiagnosticVNotes { get; set; }

        public string? UpgradeVTechnician { get; set; }


        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public byte[]? Data { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public Guid VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public DBVehicleModel Vehicle { get; set; }
    }
}
