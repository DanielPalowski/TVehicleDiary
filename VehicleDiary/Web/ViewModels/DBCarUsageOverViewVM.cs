using VehicleDiary.Core.Entities;

namespace VehicleDiary.Web.ViewModels
{
    public class DBCarUsageOverViewVM
    {
        public Guid VehicleId { get; set; }
        public string? LatestVignetteCountry { get; set; }
        public DateTime? LatestVignetteValidFrom { get; set; }
        public DateTime? LatestVignetteValidTo { get; set; }
        public float? LatestVignettePrice { get; set; }
    }
}
