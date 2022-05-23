using AutoMapper;
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
    public class UserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _repository = userRepository;
            _mapper = mapper;
        }

        public UserModel GetUserById(int id)
        {
            var userEntity = _repository.GetUserById(id);
            return _mapper.Map<UserModel>(userEntity);
        }

        public List<UserModel> GetAllUsers()
        {
            var users = _repository.GetAllUsers();
            return _mapper.Map<List<UserModel>>(users);
        }

        public int AddUser(UserModel userModel)
        {
            return _repository.AddUser(_mapper.Map<User>(userModel));
        }

        public void UpdateUser(UserModel userModel)
        {
            var userEntity = _repository.GetUserById(userModel.Id);
            _repository.UpdateUser(_mapper.Map<User>(userModel), userEntity);
        }

        public void DeleteUser(int id)
        {
            _repository.UpdateUser(id, true);
        }

        public void RestoreUser(int id)
        {
            _repository.UpdateUser(id, false);
        }

        public List<StoragedFileModel> GetUserFiles(int id)
        {
            var files = _repository.GetStoragedFilesByUserId(id);
            return _mapper.Map<List<StoragedFileModel>>(files);
        }

    }
}
