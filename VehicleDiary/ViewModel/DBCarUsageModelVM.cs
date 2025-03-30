using VehicleDiary.Models;

namespace VehicleDiary.ViewModel
{
	public class DBCarUsageModelVM
	{
		public Guid vehicleID { get; set; }
		public IEnumerable<DBPetrolModel> GettingViews {  get; set; } 
	}
}
