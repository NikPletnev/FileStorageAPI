using FileStorageAPI.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAPI.DAL.Repositories
{
    public class StoragedFileRepository : IStoragedFileRepository
    {
        private readonly FileStorageContext _context;

        public StoragedFileRepository(FileStorageContext context)
        {
            _context = context;
        }
        public StoragedFile GetStoragedFileById(int id)
        {
            return _context.StoragedFiles.Where(x => x.Id == id).Include(w => w.User).FirstOrDefault();
        }

        public List<StoragedFile> GetAllFiles() =>
            _context.StoragedFiles.Where(d => !d.IsDeleted).ToList();

        public int AddStoragedFile(StoragedFile file, User user)
        {
            file.User = user;
            var entity = _context.StoragedFiles.Add(file);
            _context.Users.FirstOrDefault(d => d.Id == user.Id).StoragedFiles.Add(file);
            _context.SaveChanges();
            return entity.Entity.Id;
        }

        public void UpdateStoragedFile(StoragedFile newFile, StoragedFile oldFile)
        {
            oldFile.Name = newFile.Name;
            oldFile.User = newFile.User;
            oldFile.Data = newFile.Data;
            _context.SaveChanges();
        }
        public void UpdateStoragedFile(int id, bool isDeleted)
        {
            var file = GetStoragedFileById(id);
            file.IsDeleted = isDeleted;
            _context.SaveChanges();
        }
        public void DeleteStoragedFileById(int id)
        {
            var file = GetStoragedFileById(id);
            _context.StoragedFiles.Remove(file);
            _context.SaveChanges();
        }

        public User GetFileOwnerByFileId(int id)
        {
            var file = GetStoragedFileById(id);
            return file.User;
        }
    }
}
