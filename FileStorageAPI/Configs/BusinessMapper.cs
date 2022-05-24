using AutoMapper;
using FileStorageAPI.BLL.Models;
using FileStorageAPI.DAL.Entity;
using FileStorageAPI.Models.InputModels;
using FileStorageAPI.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAPI.Configs
{
    public class BusinessMapper : Profile
    {
        public BusinessMapper()
        {
            CreateMap<UserModel, UserOutputModel>();
            CreateMap<UserInputModel, UserModel>();
        }

    }
}
