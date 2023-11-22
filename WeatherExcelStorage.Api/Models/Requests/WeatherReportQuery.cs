namespace WeatherExcelStorage.Api.Models.Requests;

/// <summary>
///     Запрос отчетов по погоде
/// </summary>
public sealed class WeatherReportQuery : PagedQuery, IDatetimeRange
{
    /// <inheritdoc />
    public DateTime? From { get; set; }
    
    /// <inheritdoc />
    public DateTime? To { get; set; }
}