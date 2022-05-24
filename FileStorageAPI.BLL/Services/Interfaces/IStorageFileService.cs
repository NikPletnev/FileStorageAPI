using FileStorageAPI.BLL.Models;

namespace FileStorageAPI.BLL.Services
{
    public interface IStorageFileService
    {
        int AddStoragedFile(StoragedFileModel file);
        void DeleteFileById(int id);
        List<StoragedFileModel> GetAllFiles();
        StoragedFileModel GetStoragedFileById(int id);
        void RestoreFileByid(int id);
        void UpdateStoragedFile(StoragedFileModel file);
    }
}