using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces;

namespace VehicleDiary.Application.Services.MapperService
{
    public class RepairService : IRepairService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryVehicle _repositoryVehicle;
        private readonly IRepositoryViews<DBRepairsModel> _repositoryViews;
        private readonly IRepositoryCrud<DBRepairsModel> _repositoryCrud;
        public RepairService(IMapper mapper, 
            IRepositoryVehicle repositoryVehicle,
            IRepositoryViews<DBRepairsModel> repositoryViews,
            IRepositoryCrud<DBRepairsModel> repositoryCrud)
        {
            _mapper = mapper;
            _repositoryVehicle = repositoryVehicle;
            _repositoryViews = repositoryViews;
            _repositoryCrud = repositoryCrud;
        }
        public async Task TotalCostAsync(Guid vehicleIDRoute)
        {
            var total = await _repositoryVehicle.CalculatingTotalCostRepairAsync(vehicleIDRoute);
            var calculate = await _repositoryVehicle.AddingTotalCostRepairAsync(vehicleIDRoute, total);
        }
        public async Task<IEnumerable<RepairDto>>? ShowingRepairsAsync(Guid vehicleIDRoute)
        {
            var repairs = await _repositoryViews.GetDBByVehicle(vehicleIDRoute);
            return _mapper.Map<IEnumerable<RepairDto>>(repairs);
        }
        public async Task AddingRepairAsync(RepairDto repairDto)
        {
            var entity = _mapper.Map<DBRepairsModel>(repairDto);
            await _repositoryCrud.AddAsync(entity);
        }
    }
}
