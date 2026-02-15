using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VehicleDiary.Core.Interfaces;
using VehicleDiary.Core.Constants;

namespace VehicleDiary.Core.Entities
{
    public class DBRepairVehicleModel : IVehicleEntity, IHasFile
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string RepairVCategory { get; set; }
        [Required]
        [MaxLength(100)]
        public string RepairVType { get; set; }

        [Required]
        [MaxLength(100)]
        public string RepairVName { get; set; }

        [Required]
        [MaxLength(100)]
        public string RepairVPart { get; set; }
        [Required]
        [MaxLength(100)]
        public int RepairVMileage { get; set; }

        [Required]
        [MaxLength(100)]
        public DateTime RepairVWhen { get; set; }

        [Required]
        [MaxLength(100)]
        public float RepairVPrice { get; set; }

        [MaxLength(500)]
        public string? ReapairVNotes { get; set; }
        [MaxLength(100)]
        public string? RepairVTechnician { get; set; }
        [MaxLength(100)]
        public string? RepairVPartBrand { get; set; }
        [MaxLength(100)]
        public string? RepairVPartCode { get; set; }

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
