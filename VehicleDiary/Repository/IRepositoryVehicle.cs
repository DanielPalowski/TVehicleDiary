namespace VehicleDiary.Repository;
using VehicleDiary.Models;

	public interface IRepositoryVehicle : IRepositoryCrud<DBVehicleModel>
	{
		Task<float> CalculatingTotalCostRepairAsync(Guid id);
		Task<DBVehicleModel?> AddingTotalCostRepairAsync(Guid id, float cost);
	}

