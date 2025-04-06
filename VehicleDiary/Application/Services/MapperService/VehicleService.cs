using System.Security.Claims;
using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;

namespace VehicleDiary.Application.Services.MapperService
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepositoryCrud<DBVehicleModel> _repositoryCrud;
        private readonly IRepositoryVehicle _repositoryVehicle;
        private readonly IMapper _mapper;

        public VehicleService(
            IRepositoryCrud<DBVehicleModel> repository,
            IMapper mapper,
            IRepositoryVehicle repositoryVehicle)
        {
            _repositoryCrud = repository;
            _mapper = mapper;
            _repositoryVehicle = repositoryVehicle;
        }
        public async Task AddVehicleAsync(VehicleDto vehicleDto)
        {
            var entity = _mapper.Map<DBVehicleModel>(vehicleDto);
            await _repositoryCrud.AddAsync(entity);
        }
        public async Task<IEnumerable<VehicleDto>> GettingVehiclesAsync(string userID)
        {
            var entities = await _repositoryVehicle.GetDBByIDForUserAsync(userID);
            return _mapper.Map<IEnumerable<VehicleDto>>(entities);
        }
    }
}
