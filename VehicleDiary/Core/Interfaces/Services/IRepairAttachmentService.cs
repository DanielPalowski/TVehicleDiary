using VehicleDiary.Application.DTOs;

namespace VehicleDiary.Core.Interfaces.Services
{
    public interface IRepairAttachmentService
    {
        Task AddAttachmentAsync(RepairAttachmentDto attachmentDto);
        Task RemoveAttachmentAsync(Guid id);
        Task<IEnumerable<RepairAttachmentDto>> GetAttachmentsByRepairIdAsync(Guid repairId);
    }
}
