using Microsoft.AspNetCore.Mvc;
namespace FileStorageAPI.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ILogger _logger;

        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}
