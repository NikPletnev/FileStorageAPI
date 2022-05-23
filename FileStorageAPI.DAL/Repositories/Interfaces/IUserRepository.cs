using FileStorageAPI.DAL.Entity;

namespace FileStorageAPI.DAL.Repositories
{
    public interface IUserRepository
    {
        int AddUser(User user);
        void DeleteCustomerById(int id);
        List<User> GetAllUsers();
        ICollection<StoragedFileRepository> GetStoragedFilesByUserId(int id);
        User GetUserById(int id);
        void UpdateCustomer(int id, bool isDeleted);
        void UpdateCustomer(User newUser, User oldUser);
    }
}