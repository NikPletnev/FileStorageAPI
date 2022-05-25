using FileStorageAPI.BLL.Models;

namespace FileStorageAPI.BLL.Services
{
    public interface IStorageFileService
    {
        Task<int> AddStoragedFile(StoragedFileModel file);
        Task DeleteFileById(int id);
        Task<List<StoragedFileModel>> GetAllFiles();
        Task<StoragedFileModel> GetStoragedFileById(int id);
        Task RestoreFileByid(int id);
        Task UpdateStoragedFile(StoragedFileModel file);
    }
}