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
    public class StoragedFileController : Controller
    {
        private readonly IStorageFileService _storagedFileSirvice;
        private readonly IMapper _mapper;

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get file by id")]
        public ActionResult<StoragedFileOutputModel> GetFileById(int id)
        {
            var file = _storagedFileSirvice.GetStoragedFileById(id);
            return Ok(_mapper.Map<StoragedFileModel>(file));
        }

        [HttpGet("all")]
        [SwaggerOperation(Summary = "Get all files")]
        public ActionResult<List<StoragedFileOutputModel>> GetAllFiles()
        {
            var files = _storagedFileSirvice.GetAllFiles();
            return Ok(_mapper.Map<List<StoragedFileOutputModel>>(files));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add new file")]
        public ActionResult<int> PostUser(StoragedFileInputModel model)
        {
            var fileId = _storagedFileSirvice.AddStoragedFile(_mapper.Map<StoragedFileModel>(model));
            return Ok(fileId);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update file")]
        public ActionResult UpdateFile(StoragedFileInputModel model)
        {
            _storagedFileSirvice.UpdateStoragedFile(_mapper.Map<StoragedFileModel>(model));
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete file by id")]
        public ActionResult DeleteFileById(int id)
        {
            _storagedFileSirvice.DeleteFileById(id);
            return Ok();
        }

        [HttpPatch]
        [SwaggerOperation(Summary = "Restore file by id")]
        public ActionResult RestoreFile(int id)
        {
            _storagedFileSirvice.RestoreFileByid(id);
            return Ok();
        }

    }
}
