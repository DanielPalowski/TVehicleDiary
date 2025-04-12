using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;

namespace VehicleDiary.Web.ViewModels
{
    public class DBCarUsageOverViewVM
    {
        public Guid VehicleID { get; set; }
        public TireDto LatestTireUsage { get; set; }
        public OilDto LatestOilUsage { get; set; }
        public PetrolDto LatestPetrolUsage { get; set; }
        public VignetteDto LatestVignetteUsage { get; set; }
    }
}
