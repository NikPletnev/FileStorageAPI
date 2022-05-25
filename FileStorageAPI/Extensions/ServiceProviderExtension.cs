using FileStorageAPI.BLL.Services;
using FileStorageAPI.DAL;
using FileStorageAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;

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

        public static void AddConnectionString(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FileStorageContext>(
                options => options.UseSqlServer(
            connectionString));
        }

        public static void RegisterLogger(this IServiceCollection service, IConfiguration config)
        {
            service.Configure<ConsoleLifetimeOptions>(opts => opts.SuppressStatusMessages = true);
            service.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(LogLevel.Information);
                loggingBuilder.AddNLog(config);
            });
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "FileStorageAPI", Version = "v1" });
                opt.EnableAnnotations();
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                             new string[]{}
                    }
                });
            });
        }

    }
}
