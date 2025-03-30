using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VehicleDiary.Models;

namespace VehicleDiary.ViewModel
{
	public class DBOilModelVM
	{
		[Required]
		public float OilAmount { get; set; }
		[Required]
		public DateTime OilDate { get; set; }
		[Required]
		public string OilType { get; set; }
		[Required]
		public int OilMileage { get; set; }
        [Required]
        public float OilPrice { get; set; }
        public string? OilDescription { get; set; }
        [Required]
		public Guid VehicleId { get; set; }

	}
}
