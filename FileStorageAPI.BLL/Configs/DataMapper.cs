using AutoMapper;
using FileStorageAPI.BLL.Models;
using FileStorageAPI.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAPI.DAL.Configs
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();

            CreateMap<StoragedFile, StoragedFileModel>();
            CreateMap<StoragedFileModel, StoragedFile>();
        }

    }
}
