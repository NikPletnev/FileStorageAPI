using AutoMapper;
using FileStorageAPI.BLL.Models;
using FileStorageAPI.DAL.Entity;

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
