using AutoMapper;
using FileStorageAPI.BLL.Models;
using FileStorageAPI.BLL.Services;
using FileStorageAPI.Models.InputModels;
using FileStorageAPI.Models.OutputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public ActionResult<UserOutputModel> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            return Ok(_mapper.Map<UserModel>(user));
        }

        [HttpPost]
        public ActionResult<int> PostUser(UserInputModel model)
        {
            var userId = _userService.AddUser(_mapper.Map<UserModel>(model));
            return Ok(userId);
        }


    }
}
