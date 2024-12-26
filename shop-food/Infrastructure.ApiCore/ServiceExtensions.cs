using System.Reflection;
using System.Text.RegularExpressions;
using Common.Model.Config;
using Infrastructure.ApiCore.Middleware;
using Infrastructure.ServiceHelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Infrastructure.ApiCore
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddScopedServices(this IServiceCollection services, Assembly assembly)
        {
            return services
                .AddScopedInterfaces("Service", assembly);
        }

        public static IServiceCollection AddScopedRepositories(this IServiceCollection services, Assembly assembly)
        {
            return services
                .AddScopedInterfaces("Repository", assembly);
        }

        public static IServiceCollection AddScopedHelpers(this IServiceCollection services, Assembly assembly)
        {
            return services
                .AddScopedInterfaces("Helper", assembly);
        }

        public static IServiceCollection AddInfrastructures(this IServiceCollection services)
        {
            return services
                .AddScopedServices(ServiceHelperAssembly.Assembly)
                .AddScopedHelpers(ServiceHelperAssembly.Assembly);
        }

        public static IServiceCollection AddScopedUnitOfWorkCore<TContext>(this IServiceCollection services, string connectionString)
            where TContext : DbContext
        {
            return services
                .AddDbContext<TContext>(options => { options.UseSqlServer(connectionString); })
                .AddScoped<DbContext, TContext>();
        }

        public static IServiceCollection AddCustomLogger(
            IServiceCollection services, AppConfig appConfig)
        {
            services.AddScoped(provider => provider.GetService<ILoggerFactory>().CreateLogger(appConfig.ServiceName));
            var serviceName = new Regex(@"\W+").Replace(appConfig.ServiceName, "");
            var logFormat = "shop-food" + serviceName + " {Level:u5} {Timestamp:yyyy-MM-dd HH:mm:ss} - {Message:j}{EscapedException}{NewLine}{NewLine}";
            var filePathFormat = $"{appConfig.Logging.OutputPath}{serviceName}" + "-{Date}.log";
            var retainedFileCountLimit = 10;

            var loggerConfig = new LoggerConfiguration();
            if (ApplicationMode.IsDevelopment)
            {
                loggerConfig = loggerConfig
                    .MinimumLevel.Is(LogEventLevel.Debug)
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Information);
            }
            else
            {
                loggerConfig = loggerConfig
                    .MinimumLevel.Is(LogEventLevel.Information)
                    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning);
            }

            Log.Logger = loggerConfig
                .Enrich.With(new ExceptionEnricher())
                .WriteTo.RollingFile(filePathFormat
                    , outputTemplate: logFormat
                    , retainedFileCountLimit: retainedFileCountLimit
                    , shared: true
                )
                .CreateLogger();

            services.AddLogging();

            return services;
        }

        public static IApplicationBuilder UseCustomLogger(this IApplicationBuilder app, ILoggerFactory loggerFactory, bool logRequestInput = true)
        {
            loggerFactory.AddSerilog();

            if (logRequestInput)
            {
                app.UseMiddleware<RequestInputLoggingMiddleware>();
            }

            if (ApplicationMode.IsDevelopment)
            {
            }

            return app;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, AppConfig appConfig)
        {
            return services
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc(appConfig.ServiceVersion, new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = appConfig.ServiceName,
                        Version = appConfig.ServiceVersion,
                    });

                    //options.IncludeXmlComments(Path.Combine(
                    //    PlatformServices.Default.Application.ApplicationBasePath,
                    //    "MT.Services.xml"));

                    var security = new Dictionary<string, IEnumerable<string>>
                    {
                        {"Bearer", new string[] { }},
                    };

                    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Description =
                            "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    });
                });
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, AppConfig appConfig)
        {
            app.UseSwagger(option => { option.PreSerializeFilters.Add((swaggerDoc, httpReq) => { }); });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{appConfig.ServiceVersion}/swagger.json",
                    $"DaoAnhTu {appConfig.ServiceName} API V{appConfig.ServiceVersion}");
            });

            return app;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, AppConfig appConfig)
        {
            return services;
            //return services
            //    .AddAuthentication(AppConfig.IdentityServer.DefaultScheme)
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.Authority = AppConfig.IdentityServer.Authority;
            //        options.RequireHttpsMetadata = false;

            //        options.ApiName = AppConfig.IdentityServer.ApiName;
            //        options.ApiSecret = AppConfig.IdentityServer.ApiSecret;

            //        options.EnableCaching = true;
            //        options.CacheDuration = TimeSpan.FromMinutes(10);
            //    });
        }

        public static string OverWriteConnectString(IOptions<AppConfig> options)
        {
            return string.Format("Server={0};Database={1};User Id={2};password={3};Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True;", options.Value.ConnectionStringInfo?.IPAddress, options.Value.ConnectionStringInfo?.DBName, options.Value.ConnectionStringInfo?.UserId, options.Value.ConnectionStringInfo?.Password);
        }
    }

    public class ExceptionEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent.Exception == null)
                return;

            var logEventProperty = propertyFactory.CreateProperty("EscapedException", logEvent.Exception.ToString().Replace("\r", "\\r").Replace("\n", "\\n"));
            logEvent.AddPropertyIfAbsent(logEventProperty);
        }
    }
}