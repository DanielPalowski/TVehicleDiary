using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VehicleDiary.Models;

namespace VehicleDiary.ViewModel
{
    public class DBRepairModelVM
    {
		[Required(ErrorMessage = "Please enter what repair you have done !")]
		[MaxLength(40), MinLength(2),]
		public string RepairType { get; set; }
        [MaxLength(150), MinLength(2),]
        public string? RepairDescription { get; set; }
		[Required(ErrorMessage = "Please enter the cost of this repair !")]
		public int RepairCost { get; set; }
		[Required(ErrorMessage = "Please enter the date the repair was done !")]
		[MaxLength(10), MinLength(2),]
		public string RepairMade { get; set; }
        [Required]
        public int RepairMileage { get; set; }
        [Required]
        public Guid vehicleId { get; set; }
        public IEnumerable<DBRepairsModel> RepairsView { get; set; }
        
    }
}
