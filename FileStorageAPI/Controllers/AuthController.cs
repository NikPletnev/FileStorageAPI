using FileStorageAPI.BLL.Services;
using FileStorageAPI.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace FileStorageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [SwaggerOperation(Summary = "Log In")]
        public async Task<ActionResult> LoginUser([FromBody] AuthInputModel authInputModel)
        {
            var token = await _authService.GetToken(await _authService.GetUserForLogin(authInputModel.Name,
                authInputModel.Password));

            return Ok(token);
        }

    }
}
