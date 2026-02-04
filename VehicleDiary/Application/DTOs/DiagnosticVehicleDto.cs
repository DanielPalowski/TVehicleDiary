using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleDiary.Core.Entities;

namespace VehicleDiary.Application.DTOs
{
    public class DiagnosticVehicleDto
    {
        public Guid ID { get; set; }
        public string DiagnosticVCategory { get; set; }
        public string DiagnosticVType { get; set; }
        public string? DiagnosticVErrorType { get; set; }
        public string DiagnosticVName { get; set; }
        public string? DiagnosticVErrorCode { get; set; }
        public string? DiagnosticVErrorDis { get; set; }
        public string? DiagnosticVDiagnosticType { get; set; }
        public int? DiagnosticVMileage { get; set; }
        public DateTime DiagnosticVWhen { get; set; }
        public float? DiagnosticVPrice { get; set; }
        public string? DiagnosticVNotes { get; set; }
        public string? UpgradeVTechnician { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public byte[]? Data { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public IFormFile Upload { get; set; }
        public Guid VehicleId { get; set; }

    }
}
