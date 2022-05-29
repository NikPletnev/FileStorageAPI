using FileStorageAPI.BLL.Models;

namespace FileStorageAPI.BLL.Services
{
    public interface IAuthService
    {
        Task<string> GetToken(UserModel user);
        Task<UserModel> GetUserForLogin(string name, string pass);
    }
}