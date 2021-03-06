using FileStorageAPI.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace FileStorageAPI.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FileStorageContext _context;

        public UserRepository(FileStorageContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserById(int? id) =>
            await _context.Users.Where(x => x.Id == id)
            .Include(w => w.StoragedFiles.Where(c => c.IsDeleted != true))
            .FirstOrDefaultAsync();

        public async Task<List<User>> GetAllUsers() =>
            await _context.Users.Where(d => !d.IsDeleted)
            .Include(w => w.StoragedFiles)
            .ToListAsync();

        public async Task<int> AddUser(User user)
        {
            var entity = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task UpdateUser(User newUser, User oldUser)
        {
            oldUser.Name = newUser.Name;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUser(int id, bool isDeleted)
        {
            User user = await GetUserById(id);
            user.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<StoragedFile>> GetStoragedFilesByUserId(int? id)
        {
            var user = await GetUserById(id);
            return user.StoragedFiles;
        }

        public async Task<User> GetUserByName(string userName)
        {
            return await _context.Users.Where(x => x.Name == userName)
            .Include(w => w.StoragedFiles.Where(c => c.IsDeleted != true))
            .FirstOrDefaultAsync();
        }
    }
}
