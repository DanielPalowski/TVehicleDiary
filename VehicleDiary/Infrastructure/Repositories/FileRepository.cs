using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleDiary.Core.Constants;
using VehicleDiary.Core.Entities;
using VehicleDiary.Core.Interfaces.Repositories;
using VehicleDiary.Infrastructure.Data;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Infrastructure.Repositories
{
    public class FileRepository<T> : IRepositoryFile<T> where T : class, IHasFile, new()
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public FileRepository(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task UploadAsync(IFormFile file)
        {

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);

            var entity = new T();
            entity.FileName = Path.GetFileName(file.FileName);
            entity.ContentType = file.ContentType;
            entity.Data = ms.ToArray();

            _context.Add(entity);
        }

        public async Task<FileContentResult> DownloadAsync(Guid entityId)
        {
            var entity = await _context.Set<T>().FindAsync(entityId);
            if (entity == null || entity.Data == null)
                throw new KeyNotFoundException("File not found");

            return new FileContentResult(entity.Data, entity.ContentType)
            {
                FileDownloadName = entity.FileName
            };
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
