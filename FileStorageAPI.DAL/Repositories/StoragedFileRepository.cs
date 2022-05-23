using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAPI.DAL.Repositories
{
    public class StoragedFileRepository
    {
        private readonly FileStorageContext _context;

        public StoragedFileRepository(FileStorageContext context)
        {
            _context = context;
        }

    }
}
