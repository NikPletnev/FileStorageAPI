using AutoMapper;
using FileStorageAPI.BLL.Models;
using FileStorageAPI.BLL.Services;
using FileStorageAPI.Extensions;
using FileStorageAPI.Models.InputModels;
using FileStorageAPI.Models.OutputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace FileStorageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoragedFileController : BaseController
    {
        private readonly IStorageFileService _storagedFileSirvice;
        private readonly IMapper _mapper;

        public StoragedFileController(IMapper mapper, IStorageFileService storagedFileSirvice, ILogger<StoragedFileController> logger) : base(logger)
        {
            _storagedFileSirvice = storagedFileSirvice;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get file by id")]
        public async Task<ActionResult<StoragedFileOutputModel>> GetFileById(int id)
        {
            var file = await _storagedFileSirvice.GetStoragedFileById(id);
            return Ok(_mapper.Map<StoragedFileOutputModel>(file));
        }

        [HttpGet("all")]
        [SwaggerOperation(Summary = "Get all files")]
        public async Task<ActionResult<List<StoragedFileOutputModel>>> GetAllFiles()
        {
            var files = await _storagedFileSirvice.GetAllFiles();
            return Ok(_mapper.Map<List<StoragedFileOutputModel>>(files));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add new file")]
        public async Task<ActionResult<int>> PostUser(StoragedFileInputModel model)
        {
            var fileId = await _storagedFileSirvice.AddStoragedFile(_mapper.Map<StoragedFileModel>(model));
            return Ok(fileId);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update file")]
        public async Task<ActionResult> UpdateFile(StoragedFileInputModel model)
        {
            _storagedFileSirvice.UpdateStoragedFile(_mapper.Map<StoragedFileModel>(model));
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete file by id")]
        public async Task<ActionResult> DeleteFileById(int id)
        {
            await _storagedFileSirvice.DeleteFileById(id);
            return Ok();
        }

        [HttpPatch]
        [SwaggerOperation(Summary = "Restore file by id")]
        public async Task<ActionResult> RestoreFile(int id)
        {
            await _storagedFileSirvice.RestoreFileByid(id);
            return Ok();
        }

    }
}
