using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FileStorageAPI.BLL.Configs
{
    public class AuthOptions
    {
        public const string Issuer = "FileStorageApi"; // издатель токена
        public const string Audience = "FileStorageClient"; // потребитель токена
        private const string _key = "mysupersecret_secretkey!123";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
    }
}
