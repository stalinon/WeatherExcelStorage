using WeatherExcelStorage.Api.Models;
using WeatherExcelStorage.Api.Models.Requests;

namespace WeatherExcelStorage.Core.Domain.Services;

/// <summary>
///     Сервис отчетов по погоде
/// </summary>
public interface IWeatherReportService
{
    /// <summary>
    ///     Получить список отчетов по погоде
    /// </summary>
    Task<PagedList<WeatherReport>> ListAsync(
        WeatherReportQuery query, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Загрузить файл с отчетом для сохранения
    /// </summary>
    Task UploadExcelReportAsync(
        byte[] bytes, CancellationToken cancellationToken = default);
}