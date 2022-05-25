using FileStorageAPI.BLL.Models;

namespace FileStorageAPI.BLL.Services
{
    public interface IUserService
    {
        Task<int> AddUser(UserModel userModel);
        Task DeleteUser(int id);
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<List<StoragedFileModel>> GetUserFiles(int? id);
        Task RestoreUser(int id);
        Task UpdateUser(UserModel userModel);
    }
}