using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace VehicleDiary.Web.ViewModels
{
    public class DBTiresModelVM
    {
        public Guid Id { get; set; }
        [Required]
        public float TirePrice { get; set; }
        [Required]
        public int TireAmount { get; set; }
        [Required]
        public string TireBrand { get; set; }
        [Required]
        public int TireType { get; set; }
        [Required]
        public string TireSize { get; set; }
        [Required]
        public DateTime TireDate { get; set; }
        public float? TireChangedPrice { get; set; }
        public string? TireShopWhereBought { get; set; }
        public string? TireDescription { get; set; }
        [Required]
        public Guid VehicleId { get; set; }
        public IEnumerable<DBTiresModelVM>? TireViews { get; set; }
    }
}
