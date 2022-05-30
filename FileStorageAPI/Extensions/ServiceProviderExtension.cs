using FileStorageAPI.BLL.Configs;
using FileStorageAPI.BLL.Services;
using FileStorageAPI.DAL;
using FileStorageAPI.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
            services.AddScoped<IAuthService, AuthService>();
        }

        public static void RegisterFileStorageRepositories(this IServiceCollection services)
        {
            services.AddScoped<IStoragedFileRepository, StoragedFileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddConnectionString(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FileStorageContext>(
                options => options.UseSqlServer(connectionString));

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
        public static void AddCustomAuth(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });
            services.AddAuthorization();
        }

    }
}
