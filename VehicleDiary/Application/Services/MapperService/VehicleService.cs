using System.Security.Claims;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Core.Interfaces.Services;
using VehicleDiary.Infrastructure.Data;

namespace VehicleDiary.Application.Services.MapperService
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepositoryCrud<DBVehicleModel> _repositoryCrud;
        private readonly IRepositoryVehicle _repositoryVehicle;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public VehicleService(
            IRepositoryCrud<DBVehicleModel> repository,
            IMapper mapper,
            IRepositoryVehicle repositoryVehicle,
            AppDbContext context)
        {
            _repositoryCrud = repository;
            _mapper = mapper;
            _repositoryVehicle = repositoryVehicle;
            _context = context;
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
        public async Task DeleteVehicleAsync(Guid vehicleID)
        {
            await _repositoryCrud.DeleteAsync(vehicleID);
            await _repositoryVehicle.TryRemoveByIdAsync(_context.DBRepairsSet, vehicleID);
            await _repositoryVehicle.TryRemoveByIdAsync(_context.DBOilSet, vehicleID);
            await _repositoryVehicle.TryRemoveByIdAsync(_context.DBPetrolSet, vehicleID);
            await _repositoryVehicle.TryRemoveByIdAsync(_context.DBTiresSet, vehicleID);
            await _repositoryVehicle.TryRemoveByIdAsync(_context.DBVignetteSet, vehicleID);
            await _repositoryVehicle.TryRemoveByIdAsync(_context.DBRepairVehicleSet, vehicleID);
            await _repositoryVehicle.TryRemoveByIdAsync(_context.DBDiagnosticVehicleSet, vehicleID);
            await _repositoryVehicle.TryRemoveByIdAsync(_context.DBUpgradeVehicleSet, vehicleID);
            await _context.SaveChangesAsync();
        }
        public async Task<int> CountingVehiclesAsync(string userID)
        {
            var count = await _context.DBVehiclesSet.CountAsync(x => x.UserId == userID.ToString());
            return count;
        }
        public async Task<List<DBVehicleModel>> GetVehiclesWithTotalCostAsync(string userId)
        {
            return await _repositoryVehicle.GetVehiclesWithTotalCostAsync(userId);
        }
        public async Task<int> GetTotalNumberOfUsers()
        {
            return await _repositoryVehicle.CalculatingTotalUsers();
        }
        public async Task<int> GetTotalNumberOfCars()
        {
            return await _repositoryVehicle.CalculatingTotalCars();
        }
        public async Task<int> GetTotalNumberOfServices()
        {
            return await _repositoryVehicle.CalculatingTotalServices();
        }


    }
}
