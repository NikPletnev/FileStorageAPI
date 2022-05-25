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

        public async Task<StoragedFileModel> GetStoragedFileById(int id)
        {
            var storagedFile = await _repository.GetStoragedFileById(id);
            return _mapper.Map<StoragedFileModel>(storagedFile);
        }

        public async Task<List<StoragedFileModel>> GetAllFiles()
        {
            var files = await _repository.GetAllFiles();
            return _mapper.Map<List<StoragedFileModel>>(files);
        }

        public async Task<int> AddStoragedFile(StoragedFileModel file)
        {
            var userEntitry = await _userRepository.GetUserById(file.User.Id);
            return await _repository.AddStoragedFile(_mapper.Map<StoragedFile>(file), userEntitry);
        }

        public async Task UpdateStoragedFile(StoragedFileModel file)
        {
            var fileEntity = await _repository.GetStoragedFileById(file.Id);
            if (fileEntity != null)
            {
                await _repository.UpdateStoragedFile(_mapper.Map<StoragedFile>(file), fileEntity);
            }
            else
            {
                throw new NotFoundExeption("File not found");
            }
        }

        public async Task DeleteFileById(int id)
        {
            await _repository.UpdateStoragedFile(id, true);
        }

        public async Task RestoreFileByid(int id)
        {
            await _repository.UpdateStoragedFile(id, false);
        }

    }
}
