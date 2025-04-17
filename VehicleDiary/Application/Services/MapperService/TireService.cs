using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Services.MapperService
{
    public class TireService : ITireService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryViews<DBTiresModel> _repositoryViews;
        private readonly IRepositoryCrud<DBTiresModel> _repositoryCrud;
        public TireService(
            IMapper mapper, 
            IRepositoryViews<DBTiresModel> repositoryViews,
            IRepositoryCrud<DBTiresModel> repositoryCrud)
        {
            _mapper = mapper;
            _repositoryViews = repositoryViews;
            _repositoryCrud = repositoryCrud;
        }
        public async Task<IEnumerable<TireDto>>? GetAllTiresAsync(Guid vehicleIDRoute)
        {
            var entity = await _repositoryViews.GetDBByVehicle(vehicleIDRoute);
            return _mapper.Map<IEnumerable<TireDto>>(entity);
        }
        public async Task AddingNewTiresAsync(TireDto tireDto)
        {
            var entity = _mapper.Map<DBTiresModel>(tireDto);
            await _repositoryCrud.AddAsync(entity);
        }
        public async Task RemovingAsync(Guid Id)
        {
            await _repositoryCrud.DeleteAsync(Id);
        }

    }
}
