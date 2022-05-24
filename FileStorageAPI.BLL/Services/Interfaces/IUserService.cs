using FileStorageAPI.BLL.Models;

namespace FileStorageAPI.BLL.Services
{
    public interface IUserService
    {
        int AddUser(UserModel userModel);
        void DeleteUser(int id);
        List<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        List<StoragedFileModel> GetUserFiles(int id);
        void RestoreUser(int id);
        void UpdateUser(UserModel userModel);
    }
}