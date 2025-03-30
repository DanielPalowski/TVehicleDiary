using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Identity.Client;
using VehicleDiary.Interfaces;

namespace VehicleDiary.Models
{
	public class DBVignetteModel : IVehicleEntity
	{
		public int ID { get; set; }
		[Required]
		public string VignetteCountry { get; set; }
		[Required]
		public DateTime VignetteValidFrom { get; set; }
		[Required]
		public DateTime VignetteValidTo { get; set; }
		[Required]
		public float VignettePrice { get; set; }
		public DateTime Created {  get; set; } = DateTime.Now;
		[Required]
		public Guid VehicleId { get; set; }
		[ForeignKey(nameof(VehicleId))]
		public DBVehicleModel Vehicle { get; set; }
	}
}
