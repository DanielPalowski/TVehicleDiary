namespace VehicleDiary.Repository;
using VehicleDiary.Models;

	public interface IRepositoryVehicle : IRepositoryCrud<DBVehicleModel>
	{
		Task<int> CalculatingTotalCostRepairAsync(int id);
		Task<DBVehicleModel?> AddingTotalCostRepairAsync(int id, int cost);
	}

