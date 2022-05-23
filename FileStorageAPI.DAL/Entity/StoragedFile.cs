using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAPI.DAL.Entity
{
    public  class StoragedFile
    {
        public int Id;
        public byte[] Data { get; set; }
        public string Name { get; set; }
        public int Size { get; set; } 
        public User User { get; set; }
        public bool IsDeleted { get; set; }
    }
}
