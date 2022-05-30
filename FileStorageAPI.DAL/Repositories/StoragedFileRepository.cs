using FileStorageAPI.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace FileStorageAPI.DAL.Repositories
{
    public class StoragedFileRepository : IStoragedFileRepository
    {
        private readonly FileStorageContext _context;

        public StoragedFileRepository(FileStorageContext context)
        {
            _context = context;
        }

        public async Task<StoragedFile> GetStoragedFileById(int id)
        {
            return await _context.StoragedFiles.Where(x => x.Id == id).Include(w => w.User).FirstOrDefaultAsync();
        }

        public async Task<List<StoragedFile>> GetAllFiles() =>
            await _context.StoragedFiles.Where(d => !d.IsDeleted).ToListAsync();

        public async Task<int> AddStoragedFile(StoragedFile file, User user)
        {
            file.User = user;
            var entity = await _context.StoragedFiles.AddAsync(file);
            _context.Users.FirstOrDefaultAsync(d => d.Id == user.Id).Result.StoragedFiles.Add(file);
            await _context.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task UpdateStoragedFile(StoragedFile newFile, StoragedFile oldFile)
        {
            oldFile.Name = newFile.Name;
            oldFile.User = newFile.User;
            oldFile.Data = newFile.Data;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateStoragedFile(int id, bool isDeleted)
        {
            var file = await GetStoragedFileById(id);
            file.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetFileOwnerByFileId(int id)
        {
            var file = await GetStoragedFileById(id);
            return file.User;
        }
    }
}
