using FileStorageAPI.DAL.Entity;

namespace FileStorageAPI.DAL.Repositories
{
    public interface IStoragedFileRepository
    {
        Task<int> AddStoragedFile(StoragedFile file, User user);
        Task DeleteStoragedFileById(int id);
        Task<List<StoragedFile>> GetAllFiles();
        Task<User> GetFileOwnerByFileId(int id);
        Task<StoragedFile> GetStoragedFileById(int id);
        Task UpdateStoragedFile(int id, bool isDeleted);
        Task UpdateStoragedFile(StoragedFile newFile, StoragedFile oldFile);
    }
}