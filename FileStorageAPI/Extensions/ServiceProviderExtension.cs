using FileStorageAPI.BLL.Services;
using FileStorageAPI.DAL;
using FileStorageAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FileStorageAPI.Extensions
{
    public static class ServiceProviderExtension
    {
        public static void RegisterFileStorageServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageFileService, StorageFileService>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void RegisterDogSitterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStoragedFileRepository, StoragedFileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddConnectionString(this IServiceCollection services)
        {
            services.AddDbContext<FileStorageContext>(
                options => options.UseSqlServer(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FileStorageDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
        }
    }
}
