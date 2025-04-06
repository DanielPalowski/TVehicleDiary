
using VehicleDiary.Core.Entities;


namespace VehicleDiary.Web.ViewModels
{
    public class DBCarUsageModelVM
    {
        public Guid vehicleID { get; set; }
        public IEnumerable<DBPetrolModel> GettingViews { get; set; }
    }
}
