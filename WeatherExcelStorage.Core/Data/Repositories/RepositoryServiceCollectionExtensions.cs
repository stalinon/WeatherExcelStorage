using WeatherExcelStorage.Core.Data.Repositories.Impl;

namespace WeatherExcelStorage.Core.Data.Repositories;

/// <summary>
///     Расширения для <see cref="IServiceCollection" /> <br/>
///     Репозитории
/// </summary>
internal static class RepositoryServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IWeatherReportRepository, WeatherReportRepository>();

        return services;
    }
}