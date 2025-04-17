using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;

namespace VehicleDiary.Application.Services.MapperService
{
    public class OilService : IOilService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryVehicle _repositoryVehicle;
        private readonly IRepositoryViews<DBOilModel> _repositoryViews;
        private readonly IRepositoryCrud<DBOilModel> _repositoryCrud;
        public OilService(IMapper mapper,
            IRepositoryVehicle repositoryVehicle,
            IRepositoryViews<DBOilModel> repositoryViews,
            IRepositoryCrud<DBOilModel> repositoryCrud)
        {
            _mapper = mapper;
            _repositoryVehicle = repositoryVehicle;
            _repositoryViews = repositoryViews;
            _repositoryCrud = repositoryCrud;
        }
        public async Task<IEnumerable<OilDto>>? GettingOiLViewAsync(Guid vehicleIDRoute)
        {
            var entity = await _repositoryViews.GetDBByVehicle(vehicleIDRoute);
            return _mapper.Map<IEnumerable<OilDto>>(entity);
        }
        public async Task AddingOilAsync(OilDto oilDto)
        {
            var entity = _mapper.Map<DBOilModel>(oilDto);
            await  _repositoryCrud.AddAsync(entity);
        }
        public async Task RemovingAsync(Guid Id)
        {
            await _repositoryCrud.DeleteAsync(Id);
        }
    }
}
