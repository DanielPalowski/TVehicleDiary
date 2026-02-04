using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Mappings
{
    public class DiagnosticVehicleProfile : Profile
    {
        public DiagnosticVehicleProfile()
        {
            CreateMap<DBDiagnosticVehicleModel, DiagnosticVehicleDto>();
            CreateMap<DiagnosticVehicleDto, DBDiagnosticVehicleModel>();
            CreateMap<DBDiagnosticVehicleModelVM, DiagnosticVehicleDto>();
            CreateMap<DiagnosticVehicleDto, DBDiagnosticVehicleModelVM>();
        }
    }
}
