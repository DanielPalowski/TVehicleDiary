namespace VehicleDiary.Repository;
using VehicleDiary.Models;

	public interface IRepositoryVehicle : IRepositoryCrud<DBVehicleModel>
	{
		Task<float> CalculatingTotalCostRepairAsync(int id);
		Task<DBVehicleModel?> AddingTotalCostRepairAsync(int id, float cost);
	}

