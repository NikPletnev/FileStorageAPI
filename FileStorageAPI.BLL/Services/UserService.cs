using AutoMapper;
using FileStorageAPI.BLL.Exeptions;
using FileStorageAPI.BLL.Models;
using FileStorageAPI.DAL.Entity;
using FileStorageAPI.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStorageAPI.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _repository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserModel> GetUserById(int id)
        {
            var userEntity = await _repository.GetUserById(id);
            return _mapper.Map<UserModel>(userEntity);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = await _repository.GetAllUsers();
            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<int> AddUser(UserModel userModel)
        {
            return await _repository.AddUser(_mapper.Map<User>(userModel));
        }

        public async Task UpdateUser(UserModel userModel)
        {
            var userEntity = await _repository.GetUserById(userModel.Id);
            if (userEntity != null)
            {
                await _repository.UpdateUser(_mapper.Map<User>(userModel), userEntity);
            }
            else
            {
                throw new NotFoundExeption("File not found");
            }
        }

        public async Task DeleteUser(int id)
        {
            await _repository.UpdateUser(id, true);
        }

        public async Task RestoreUser(int id)
        {
            await _repository.UpdateUser(id, false);
        }

        public async Task<List<StoragedFileModel>> GetUserFiles(int? id)
        {
            var files = await _repository.GetStoragedFilesByUserId(id);
            return _mapper.Map<List<StoragedFileModel>>(files);
        }

    }
}
