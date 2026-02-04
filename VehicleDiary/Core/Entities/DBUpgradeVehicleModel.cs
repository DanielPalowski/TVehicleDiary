using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VehicleDiary.Core.Interfaces;
using VehicleDiary.Core.Constants;

namespace VehicleDiary.Core.Entities
{
    public class DBUpgradeVehicleModel : IVehicleEntity, IHasFile
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string UpgradeVCategory { get; set; }
        [Required]
        [MaxLength(100)]
        public string UpgradeVType { get; set; }
        [Required]
        [MaxLength(100)]
        public string UpgradeVStatus { get; set; }

        [Required]
        [MaxLength(100)]
        public string UpgradeVName { get; set; }

        [Required]
        [MaxLength(9)]
        public int UpgradeVMileage { get; set; }

        [Required]
        public DateTime UpgradeVWhen { get; set; }

        [Required]
        [MaxLength(20)]
        public float UpgradeVPrice { get; set; }

        public string? UpgradeVNotes { get; set; }

        public string? UpgradeVTechnician { get; set; }

        public string? UpgradeVPartBrand { get; set; }

        public string? UpgradeVPartCode { get; set; }

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
