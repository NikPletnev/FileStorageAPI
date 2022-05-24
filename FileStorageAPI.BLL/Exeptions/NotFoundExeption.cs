using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAPI.BLL.Exeptions
{
    public class NotFoundExeption : Exception
    {
        public NotFoundExeption(string message) : base(message) { }
    }
}
