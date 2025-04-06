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
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        public string? Description { get; set; }
        public int MadeYear { get; set; }
        public string? License_plate { get; set; }
        public string? VIN { get; set; }
        public int Power { get; set; }
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
