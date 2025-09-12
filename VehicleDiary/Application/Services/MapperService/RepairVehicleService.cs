using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
namespace VehicleDiary.Application.Services.MapperService
{ 

    public class RepairVehicleService : IRepairVehicleService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryViews<DBRepairVehicleModel> _repositoryViews;
        private readonly IRepositoryCrud<DBRepairVehicleModel> _repositoryCrud;

        public RepairVehicleService(
            IMapper mapper,
            IRepositoryViews<DBRepairVehicleModel> repositoryViews,
            IRepositoryCrud<DBRepairVehicleModel> repositoryCrud)
        {
            _mapper = mapper;
            _repositoryViews = repositoryViews;
            _repositoryCrud = repositoryCrud;
        }

        public async Task<IEnumerable<RepairVehicleDto>> GettingRepairViewAsync(Guid vehicleIDRoute)
        {
            var entity = await _repositoryViews.GetDBByVehicle(vehicleIDRoute);
            return _mapper.Map<IEnumerable<RepairVehicleDto>>(entity);
        }

        public async Task<Guid> AddingRepairAsync(RepairVehicleDto repairDto)
        {
            var entity = _mapper.Map<DBRepairVehicleModel>(repairDto);
            await _repositoryCrud.AddAsync(entity);
            return entity.ID;
        }

        public async Task RemovingAsync(Guid Id)
        {
            await _repositoryCrud.DeleteAsync(Id);
        }
    }
}
