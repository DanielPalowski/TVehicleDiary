using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Infrastructure.Repositories;
using VehicleDiary.Web.ViewModels;
namespace VehicleDiary.Application.Services.MapperService
{ 

    public class RepairVehicleService : IRepairVehicleService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryViews<DBRepairVehicleModel> _repositoryViews;
        private readonly IRepositoryCrud<DBRepairVehicleModel> _repositoryCrud;
        private readonly IRepositoryFile<DBRepairVehicleModel> _repositoryFile;

        public RepairVehicleService(
            IMapper mapper,
            IRepositoryViews<DBRepairVehicleModel> repositoryViews,
            IRepositoryCrud<DBRepairVehicleModel> repositoryCrud,
            IRepositoryFile<DBRepairVehicleModel> repositoryFile)
        {
            _mapper = mapper;
            _repositoryViews = repositoryViews;
            _repositoryCrud = repositoryCrud;
            _repositoryFile = repositoryFile;
        }

        public async Task<IEnumerable<RepairVehicleDto>> GettingRepairViewAsync(Guid vehicleIDRoute)
        {
            var entity = await _repositoryViews.GetDBByVehicle(vehicleIDRoute);
            return _mapper.Map<IEnumerable<RepairVehicleDto>>(entity);
        }

        public async Task<Guid> AddingRepairAsync(RepairVehicleDto repairDto)
        {
            var entity = _mapper.Map<DBRepairVehicleModel>(repairDto);

            if (repairDto.Upload != null && repairDto.Upload.Length > 0)
            {
                using var ms = new MemoryStream();
                await repairDto.Upload.CopyToAsync(ms);
                entity.FileName = Path.GetFileName(repairDto.Upload.FileName);
                entity.ContentType = repairDto.Upload.ContentType;
                entity.Data = ms.ToArray();
            }

            await _repositoryCrud.AddAsync(entity);
            return entity.ID;
        }

        public async Task RemovingAsync(Guid Id)
        {
            await _repositoryCrud.DeleteAsync(Id);
        }
        public async Task UploadingAsync(RepairVehicleDto repairDto)
        {
            if(repairDto.Upload != null && repairDto.Upload.Length > 0)
            {
                await _repositoryFile.UploadAsync(repairDto.Upload);
            }
        }
        public async Task<FileContentResult> DownloadingAsync(Guid id)
        {
            return await _repositoryFile.DownloadAsync(id);
        }
    }
}
