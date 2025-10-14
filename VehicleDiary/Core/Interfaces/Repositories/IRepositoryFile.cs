using VehicleDiary.Core.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VehicleDiary.Core.Interfaces.Repositories
{
    public interface IRepositoryFile<T> where T : class, IHasFile
    {
        Task UploadAsync(IFormFile file);
        Task<FileContentResult> DownloadAsync(Guid entityId);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
