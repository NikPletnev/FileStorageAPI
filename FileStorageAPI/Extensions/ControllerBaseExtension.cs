using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FileStorageAPI.Extensions
{
    public static class ControllerBaseExtension
    {
        public static int? GetUserId(this ControllerBase controllerBase)
        {
            if (controllerBase.HttpContext.User.Identity is not ClaimsIdentity identity)
                return null;

            if (!int.TryParse(identity.FindFirst(ClaimTypes.UserData)?.Value, out var userId))
                return null;

            return userId;
        }
    }
}
