using Common.Model.Config;
using Infrastructure.ApiCore;
using shop_food_authen.Contexts;
using shop_food_authen.Services;

try
{
    var builder = WebApplication.CreateBuilder(args);
    var env = builder.Environment.EnvironmentName;
    IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{env}.json", true, true)
        .AddEnvironmentVariables()
        .Build();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<EntityDBContext>();
    builder.Services.AddInfrastructures();
    builder.Services.AddScopedServices(ServiceAssembly.Assembly);
    builder.Services.Configure<AppConfig>(configuration.GetSection("AppConfig"));

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    //app.UseMiddleware<AuthenticationMiddleware>();
    //app.UseMiddleware<TokenDecodedMiddleware>();
    app.Urls.Add("http://localhost:1111");
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("tutv19");
}