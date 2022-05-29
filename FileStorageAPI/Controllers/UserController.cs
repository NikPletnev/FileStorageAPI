using AutoMapper;
using FileStorageAPI.BLL.Models;
using FileStorageAPI.BLL.Services;
using FileStorageAPI.Extensions;
using FileStorageAPI.Models.InputModels;
using FileStorageAPI.Models.OutputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FileStorageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService, ILogger<StoragedFileController> logger) : base(logger)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get user by id")]
        public async Task<ActionResult<UserOutputModel>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(_mapper.Map<UserOutputModel>(user));
        }

        [HttpGet("all")]
        [SwaggerOperation(Summary = "Get all users")]
        public async Task<ActionResult<List<UserOutputModel>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(_mapper.Map<List<UserOutputModel>>(users));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add new user")]
        public async Task<ActionResult<int>> PostUser(UserInputModel model)
        {
            var userId = await _userService.AddUser(_mapper.Map<UserModel>(model));
            return Ok(userId);
        }

        [Authorize]
        [HttpPut]
        [SwaggerOperation(Summary = "Update user")]
        public async Task<ActionResult> UpdateUser(UserInputModel model)
        {
            await _userService.UpdateUser(_mapper.Map<UserModel>(model));
            return Ok();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete user by id")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }

        [HttpPatch]
        [SwaggerOperation(Summary = "Restore user by id")]
        public async Task<ActionResult> RestoreUser(int id)
        {
            await _userService.RestoreUser(id);
            return Ok();
        }

        [Authorize]
        [HttpGet("{id}/files")]
        [SwaggerOperation(Summary = "Get user files")]
        public async Task<ActionResult<List<StoragedFileOutputModel>>> GetUserFiles(int id)
        {
            var files = await _userService.GetUserFiles(id);
            return Ok(_mapper.Map<List<StoragedFileOutputModel>>(files));
        }
    }
}
