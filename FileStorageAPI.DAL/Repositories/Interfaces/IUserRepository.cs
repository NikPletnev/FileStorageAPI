using FileStorageAPI.DAL.Entity;

namespace FileStorageAPI.DAL.Repositories
{
    public interface IUserRepository
    {
        int AddUser(User user);
        void DeleteUserById(int id);
        List<User> GetAllUsers();
        ICollection<StoragedFile> GetStoragedFilesByUserId(int? id);
        User GetUserById(int? id);
        void UpdateUser(int id, bool isDeleted);
        void UpdateUser(User newUser, User oldUser);
    }
}