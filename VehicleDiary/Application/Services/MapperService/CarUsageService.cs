using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Services.MapperService
{
    public class CarUsageService : ICarUsageService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryCarUsage _repositoryCarUsage;
        public CarUsageService(IMapper mapper,
            IRepositoryCarUsage repositoryCarUsage)

        {
            _mapper = mapper;
            _repositoryCarUsage = repositoryCarUsage;
        }
        public async Task<TireDto> LatestTireUsageAsync(Guid vehicleIDRoute)
        {
           var entity = await _repositoryCarUsage.GettingLatestTiresAsync(vehicleIDRoute);
           var dto = _mapper.Map<TireDto>(entity);
           return dto;
        }
        public async Task<PetrolDto> LatestPetrolUsageAsync(Guid vehicleIDRoute)
        {
            var entity = await _repositoryCarUsage.GettingLatestPetrolAsync(vehicleIDRoute);
            var dto = _mapper.Map<PetrolDto>(entity);
            return dto;
        }
        public async Task<OilDto> LatestOilUsageAsync(Guid vehicleIDRoute)
        {
            var entity = await _repositoryCarUsage.GettingLatestOilAsync(vehicleIDRoute);
            var dto = _mapper.Map<OilDto>(entity);
            return dto;
        }
        public async Task<VignetteDto> LatestVignetteUsageAsync(Guid vehicleIDRoute)
        {
            var entity = await _repositoryCarUsage.GettingLatestVignetteAsync(vehicleIDRoute);
            var dto = _mapper.Map<VignetteDto>(entity);
            return dto;
        }
    }
}
