using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Constants;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;

namespace VehicleDiary.Application.Services.MapperService
{
    public class UpgradeVehicleService : IUpgradeVehicleService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryViews<DBUpgradeVehicleModel> _repositoryViews;
        private readonly IRepositoryCrud<DBUpgradeVehicleModel> _repositoryCrud;
        private readonly IRepositoryFile<DBUpgradeVehicleModel> _repositoryFile;
        
        public UpgradeVehicleService(IMapper mapper, IRepositoryViews<DBUpgradeVehicleModel> repositoryViews, IRepositoryCrud<DBUpgradeVehicleModel> repositoryCrud,
            IRepositoryFile<DBUpgradeVehicleModel> repositoryFile)
        {
            _mapper = mapper;
            _repositoryViews = repositoryViews;
            _repositoryCrud = repositoryCrud;
            _repositoryFile = repositoryFile;
        }
        public async Task<IEnumerable<UpgradeVehicleDto>> GettingRepairViewAsync(Guid vehicleIDRoute)
        {
            var entity = await _repositoryViews.GetDBByVehicle(vehicleIDRoute);
            return _mapper.Map<IEnumerable<UpgradeVehicleDto>>(entity);
        }

        public async Task<Guid> AddingRepairAsync(UpgradeVehicleDto repairDto)
        {
            var entity = _mapper.Map<DBUpgradeVehicleModel>(repairDto);

            if (repairDto.Upload != null && repairDto.Upload.Length > 0)
            {
                ValidationFile(repairDto.Upload);

                using var ms = new MemoryStream();
                await repairDto.Upload.CopyToAsync(ms);

                if (ms.Length > IFileSizeMax.MAX_FILE_SIZE)
                {
                    throw new Exception($"File size exceeds the maximum limit of {IFileSizeMax.MAX_FILE_SIZE / (1024 * 1024)} MB.");
                }

                entity.FileName = Path.GetFileName(repairDto.Upload.FileName);
                entity.ContentType = repairDto.Upload.ContentType;
                entity.Data = ms.ToArray();
            }

            await _repositoryCrud.AddAsync(entity);
            return entity.ID;
        }

        private void ValidationFile(IFormFile file)
        {
            if (file.Length > IFileSizeMax.MAX_FILE_SIZE)
            {
                throw new Exception($"File size exceeds the maximum limit of {IFileSizeMax.MAX_FILE_SIZE / (1024 * 1024)} MB.");
            }

            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !IFileSizeMax.PERMITTED_EXTENSIONS.Contains(ext))
            {
                throw new Exception("Invalid file type. Only the following types are allowed: " + string.Join(", ", IFileSizeMax.PERMITTED_EXTENSIONS));
            }
        }

        public async Task RemovingAsync(Guid Id)
        {
            await _repositoryCrud.DeleteAsync(Id);
        }
        public async Task UploadingAsync(UpgradeVehicleDto repairDto)
        {
            ValidationFile(repairDto.Upload);
            if (repairDto.Upload != null && repairDto.Upload.Length > 0)
            {
                await _repositoryFile.UploadAsync(repairDto.Upload);
            }
        }
        public async Task<FileContentResult> DownloadingAsync(Guid id)
        {
            return await _repositoryFile.DownloadAsync(id);
        }
       /* public async Task<int> CountingAsync(Guid vehicleIDRoute)
        {
            return await _repositoryViews.CountAsync(vehicleIDRoute);
        }*/
    }
}
