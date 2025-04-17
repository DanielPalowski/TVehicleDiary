using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;

namespace VehicleDiary.Application.Services.MapperService
{
    public class VignetteService : IVignetteService
	{
		private readonly IMapper _mapper;
		private readonly IRepositoryVehicle _repositoryVehicle;
		private readonly IRepositoryViews<DBVignetteModel> _repositoryViews;
		private readonly IRepositoryCrud<DBVignetteModel> _repositoryCrud;
		public VignetteService(IMapper mapper,
			IRepositoryVehicle repositoryVehicle,
			IRepositoryViews<DBVignetteModel> repositoryViews,
			IRepositoryCrud<DBVignetteModel> repositoryCrud)
		{
			_mapper = mapper;
			_repositoryVehicle = repositoryVehicle;
			_repositoryViews = repositoryViews;
			_repositoryCrud = repositoryCrud;
		}
		public async Task<IEnumerable<VignetteDto>>? GettingVignetteAsync(Guid vehicleIDRoute)
		{
			var entity = await _repositoryViews.GetDBByVehicle(vehicleIDRoute);
			return _mapper.Map<IEnumerable<VignetteDto>>(entity);
		}
		public async Task AddingVignetteAsync (VignetteDto vignetteDto)
		{
            var entity = _mapper.Map<DBVignetteModel>(vignetteDto);
            await _repositoryCrud.AddAsync(entity);
        }
        public async Task RemovingAsync(Guid Id)
        {
            await _repositoryCrud.DeleteAsync(Id);
        }

    }
}
