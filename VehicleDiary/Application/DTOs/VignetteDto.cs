using System.ComponentModel.DataAnnotations;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.DTOs
{
	public class VignetteDto
	{
		public Guid Id { get; set; }
		public string VignetteCountry { get; set; }
		public DateTime VignetteValidFrom { get; set; }
		public DateTime VignetteValidTo { get; set; }
		public float VignettePrice { get; set; }
		public Guid vehicleId { get; set; }
	}
}
