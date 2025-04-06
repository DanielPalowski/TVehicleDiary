using AutoMapper;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;

namespace VehicleDiary.Application.Services.MapperService
{
    public class CarUsageService : ICarUsageService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryCrud<DBPetrolModel> _repositoryPetrol;
        private readonly IRepositoryCrud<DBVignetteModel> _repositoryVignette;
        private readonly IRepositoryCrud<DBOilModel> _repositoryOil;
        private readonly IRepositoryCrud<DBTiresModel> _repositoryTires;
        private readonly IRepositoryViews<DBPetrolModel> _repositoryView;
        private readonly CountryService _countryService;
        public CarUsageService(IMapper mapper,
            IRepositoryCrud<DBPetrolModel> repository,
            IRepositoryViews<DBPetrolModel> repositoryView,
            CountryService countryService,
            IRepositoryCrud<DBVignetteModel> repositoryVignette,
            IRepositoryCrud<DBOilModel> repositoryOil,
            IRepositoryCrud<DBTiresModel> repositoryTires)

        {
            _mapper = mapper;
            _repositoryPetrol = repository;
            _repositoryView = repositoryView;
            _countryService = countryService;
            _repositoryVignette = repositoryVignette;
            _repositoryOil = repositoryOil;
            _repositoryTires = repositoryTires;

        }
    }
}
