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
    public class BaseController : Controller
    {
        protected readonly ILogger _logger;

        public BaseController(ILogger logger)
        {
            _logger = logger;
        }
    }
}
