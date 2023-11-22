using WeatherExcelStorage.Core.Data.Entities;

namespace WeatherExcelStorage.Core.Data.Repositories.Impl;

/// <inheritdoc cref="IWeatherReportRepository" />
internal sealed class WeatherReportRepository : Repository<WeatherReportEntity>, IWeatherReportRepository
{
    /// <inheritdoc cref="WeatherReportRepository" />
    public WeatherReportRepository(DatabaseContext dbContext) : base(dbContext)
    { }
}