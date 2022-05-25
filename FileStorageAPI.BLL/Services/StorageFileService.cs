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
    public class StorageFileService : IStorageFileService
    {
        private readonly IStoragedFileRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public StorageFileService(IStoragedFileRepository repository, IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public StoragedFileModel GetStoragedFileById(int id)
        {
            var storagedFile = _repository.GetStoragedFileById(id);
            return _mapper.Map<StoragedFileModel>(storagedFile);
        }

        public List<StoragedFileModel> GetAllFiles()
        {
            var files = _repository.GetAllFiles();
            return _mapper.Map<List<StoragedFileModel>>(files);
        }

        public int AddStoragedFile(StoragedFileModel file)
        {
            var userEntitry = _userRepository.GetUserById(file.User.Id);
            return _repository.AddStoragedFile(_mapper.Map<StoragedFile>(file), userEntitry);
        }

        public void UpdateStoragedFile(StoragedFileModel file)
        {
            var fileEntity = _repository.GetStoragedFileById(file.Id);
            if (fileEntity != null)
            {
                _repository.UpdateStoragedFile(_mapper.Map<StoragedFile>(file), fileEntity);
            }
            else
            {
                throw new NotFoundExeption("File not found");
            }
        }

        public void DeleteFileById(int id)
        {
            _repository.UpdateStoragedFile(id, true);
        }

        public void RestoreFileByid(int id)
        {
            _repository.UpdateStoragedFile(id, false);
        }

    }
}
