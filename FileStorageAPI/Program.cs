using FileStorageAPI.Configs;
using FileStorageAPI.DAL.Configs;
using FileStorageAPI.Extensions;
using FileStorageAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
const string _connectionStringVariableName = "CONNECTION_STRING";
const string _logDirectoryVariableName = "LOG_DIRECTORY";

string connString = builder.Configuration.GetValue<string>(_connectionStringVariableName);
string logDirectory = builder.Configuration.GetValue<string>(_logDirectoryVariableName);

var config = new ConfigurationBuilder()
           .SetBasePath(logDirectory)
           .AddXmlFile("NLog.config", optional: true, reloadOnChange: true)
           .Build();

builder.Services.AddAutoMapper(typeof(BusinessMapper).Assembly, typeof(DataMapper).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterFileStorageServices();
builder.Services.RegisterDogSitterRepositories();
builder.Services.AddConnectionString(connString);
builder.Services.AddSwagger();
builder.Services.RegisterLogger(config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExeptionHandler>();

app.MapControllers();

app.Run();
