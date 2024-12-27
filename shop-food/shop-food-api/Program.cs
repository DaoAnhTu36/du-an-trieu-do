using Common.Model.Config;
using Infrastructure.ApiCore;
using Infrastructure.ApiCore.Middleware;
using Serilog;
using shop_food_api.DatabaseContext;
using shop_food_api.Repositories;
using shop_food_api.Services;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment.EnvironmentName;
IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{env}.json", true, true)
        .AddJsonFile($"logsettings.json", true, true)
        .AddEnvironmentVariables()
        .Build();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenCustom();
builder.Services.AddDbContext<EntityDBContext>();
builder.Services.AddInfrastructures();
builder.Services.AddScopedServices(ServiceAssembly.Assembly);
builder.Services.AddScopedRepositories(RepositoryAssembly.Assembly);
builder.Services.AddScopedUnitOfWorkCore<EntityDBContext>(ServiceExtensions.OverWriteConnectString(configuration.GetSection("AppConfig")));
builder.Services.Configure<AppConfig>(configuration.GetSection("AppConfig"));
builder.Services.AddLog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<TokenDecodedMiddleware>();
app.Urls.Add("http://localhost:1112");
app.Run();