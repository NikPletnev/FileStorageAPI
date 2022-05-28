using FileStorageAPI.DAL.Entity;

namespace FileStorageAPI.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<int> AddUser(User user);
        Task<List<User>> GetAllUsers();
        Task<ICollection<StoragedFile>> GetStoragedFilesByUserId(int? id);
        Task<User> GetUserById(int? id);
        Task UpdateUser(int id, bool isDeleted);
        Task UpdateUser(User newUser, User oldUser);
    }
}