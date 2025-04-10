﻿using VehicleDiary.Application.DTOs;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IVignetteService
    {
        Task<IEnumerable<VignetteDto>>? GettingVignetteAsync(Guid vehicleIDRoute);
        Task AddingVignetteAsync(VignetteDto vignette);
    }
}
