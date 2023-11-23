using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Swashbuckle.AspNetCore.SwaggerUI;
using WeatherExcelStorage.Core.Configuration;
using WeatherExcelStorage.Core.Data;
using WeatherExcelStorage.Core.Data.Repositories;
using WeatherExcelStorage.Core.Domain.Services;
using WeatherExcelStorage.Core.Domain.Services.Impl;

namespace WeatherExcelStorage.Core;

/// <summary>
///     Конфигурация приложения
/// </summary>
public sealed class Startup
{
    /// <inheritdoc cref="Startup" />
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    ///     Свойства конфигурации
    /// </summary>
    private IConfiguration Configuration { get; }
    
    /// <summary>
    ///     Настройка DI-контейнера
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddMvc();
        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Version = "v1",
                Title = "WeatherExcelStorage.Core API",
                Description = "ASP.NET Core Web API"
            });
        });
        
        ConfigureDatabase(services, Configuration);

        services.AddSingleton<IWeatherReportService, WeatherReportService>();
    }
    
    /// <summary>
    ///     Метод конфигурации пайплайна HTTP
    /// </summary>
    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env,
        IServiceProvider serviceProvider,
        IHostApplicationLifetime lifetime)
    {
        app.UseStaticFiles();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        });
    }

    private void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetValue<string>(Constants.Storage.CONNECTION_STRING);
        
        services.AddDbContext<DatabaseContext>(option =>
        {
            option.UseNpgsql(dbConnectionString);
        });

        services.AddRepositories();
    }
}