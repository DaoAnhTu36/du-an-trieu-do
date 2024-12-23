using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var env = builder.Environment.EnvironmentName;
IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{env}.json", true, true)
        .AddJsonFile("ocelot.json") // primary config file
        .AddJsonFile($"ocelot.{env}.json") // environment file
        .AddEnvironmentVariables()
        .Build();
builder.Services.AddOcelot(configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseOcelot().Wait();
app.UseAuthorization();
app.MapControllers();
app.Run();