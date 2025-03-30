using VehicleDiary.Models;

namespace VehicleDiary.ViewModel
{
	public class CarUsageModelVM
	{
		public Guid vehicleID { get; set; }
		public IEnumerable<DBPetrolModel> GettingViews {  get; set; } 
	}
}
