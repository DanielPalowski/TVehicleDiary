using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;

namespace VehicleDiary.Application.Services.MapperService
{
    public class PetrolService : IPetrolService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryCrud<DBPetrolModel> _repositoryCrud;
        private readonly IRepositoryViews<DBPetrolModel> _repositoryView;
        public PetrolService(IMapper mapper, IRepositoryCrud<DBPetrolModel> repositoryCrud, IRepositoryViews<DBPetrolModel> repositoryView)
        {
            _mapper = mapper;
            _repositoryCrud = repositoryCrud;
            _repositoryView = repositoryView;
        }
        public async Task<IEnumerable<PetrolDto>>? GetAllPetrolModelsAsync(Guid vehicleIDRoute)
        {
            var entity = await _repositoryView.GetDBByVehicle(vehicleIDRoute);
            return _mapper.Map<IEnumerable<PetrolDto>>(entity);
        }
        public async Task AddingPetrolAsync(PetrolDto petrolDto)
        {
            var entity = _mapper.Map<DBPetrolModel>(petrolDto);
            await _repositoryCrud.AddAsync(entity);
        }
        public async Task RemovingAsync(Guid Id)
        {
            await _repositoryCrud.DeleteAsync(Id);
        }
    }
}
