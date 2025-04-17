using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace VehicleDiary.Web.ViewModels
{
    public class DBVignetteModelVM
    {
        public Guid Id { get; set; }
        [Required]
        public string VignetteCountry { get; set; }
        [Required]
        [Display(Name = "Valid From")]
        public DateTime VignetteValidFrom { get; set; }
        [Required]
        [Display(Name = "Valid To")]
        public DateTime VignetteValidTo { get; set; }
        [Required]
        public float VignettePrice { get; set; }
        [Required]
        public Guid vehicleId { get; set; }
		public IEnumerable<DBVignetteModelVM>? VignetteView { get; set; }

	}
}
