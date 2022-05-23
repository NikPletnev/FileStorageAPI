using FileStorageAPI.DAL.Entity;

namespace FileStorageAPI.DAL.Repositories
{
    public interface IStoragedFileRepository
    {
        int AddStoragedFile(StoragedFile file);
        void DeleteStoragedFileById(int id);
        List<StoragedFile> GetAllFiles();
        User GetFileOwnerByFileId(int id);
        StoragedFile GetStoragedFileById(int id);
        void UpdateStoragedFile(int id, bool isDeleted);
        void UpdateStoragedFile(StoragedFile newFile, StoragedFile oldFile);
    }
}