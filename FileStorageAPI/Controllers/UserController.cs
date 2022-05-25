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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get user by id")]
        public ActionResult<UserOutputModel> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            return Ok(_mapper.Map<UserModel>(user));
        }

        [HttpGet("all")]
        [SwaggerOperation(Summary = "Get all users")]
        public ActionResult<List<UserOutputModel>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(_mapper.Map<List<UserOutputModel>>(users));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add new user")]
        public ActionResult<int> PostUser(UserInputModel model)
        {
            var userId = _userService.AddUser(_mapper.Map<UserModel>(model));
            return Ok(userId);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update user")]
        public ActionResult UpdateUser(UserInputModel model)
        {
            _userService.UpdateUser(_mapper.Map<UserModel>(model));
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete user by id")]
        public ActionResult DeleteUserById(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }

        [HttpPatch]
        [SwaggerOperation(Summary = "Restore user by id")]
        public ActionResult RestoreUser(int id)
        {
            _userService.RestoreUser(id);
            return Ok();
        }

        [HttpGet("{id}/files")]
        [SwaggerOperation(Summary = "Get user files")]
        public ActionResult<List<StoragedFileOutputModel>> GetUserFiles(int id)
        {
            var files = _userService.GetUserFiles(id);
            return Ok(_mapper.Map<List<StoragedFileOutputModel>>(files));
        }
    }
}
