using Infrastructure.ApiCore;
using Infrastructure.ApiCore.Middleware;
using shop_food_authen.Contexts;
using shop_food_authen.Services;

var builder = WebApplication.CreateBuilder(args);

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

//app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<TokenDecodedMiddleware>();

app.Run("http://localhost:1111");