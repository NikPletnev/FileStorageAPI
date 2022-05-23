using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAPI.BLL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<StoragedFileModel> StoragedFiles { get; set; }
    }
}
