using AutoMapper;
using FileStorageAPI.BLL.Models;
using FileStorageAPI.Models.InputModels;
using FileStorageAPI.Models.OutputModels;

namespace FileStorageAPI.Configs
{
    public class BusinessMapper : Profile
    {
        public BusinessMapper()
        {
            CreateMap<UserModel, UserOutputModel>();
            CreateMap<UserInputModel, UserModel>();

            CreateMap<StoragedFileModel, StoragedFileOutputModel>();
            CreateMap<StoragedFileInputModel, StoragedFileModel>()
                .ForMember(m => m.User, opt => opt.MapFrom(o => new UserModel { Id = o.UserId }))
                .ForMember(m => m.Data, opt => opt.MapFrom(o => Convert.FromBase64String(o.Data)));

        }

    }
}
