using Infrastructure.ApiCore;
using Infrastructure.ApiCore.Middleware;
using shop_food_api.DatabaseContext;
using shop_food_api.Services;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment.EnvironmentName;
IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{env}.json", true, true)
        .AddEnvironmentVariables()
        .Build();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EntityDBContext>();
builder.Services.AddInfrastructures();
builder.Services.AddScopedServices(ServiceAssembly.Assembly);

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