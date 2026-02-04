using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VehicleDiary.Core.Entities
{
    public class DBVehicleModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Model { get; set; }
        [MaxLength(300)]
        public string? Description { get; set; }
        [MaxLength(4)]
        public int MadeYear { get; set; }
        [MaxLength(10)]
        public string? STK { get; set; }
        [MaxLength(10)]
        public string? License_plate { get; set; }
        [MaxLength(20)]
        public string? VIN { get; set; }
        [MaxLength(5)]
        public int Power { get; set; }
        [MaxLength(20)]
        public string? Insurence { get; set; }
        public DateTime? Bought { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public float? RepairCost { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }

    }
}
