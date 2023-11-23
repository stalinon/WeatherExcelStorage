using Microsoft.AspNetCore.Mvc;

namespace WeatherExcelStorage.Api.Models.Requests;

/// <summary>
///     Запрос отчетов по погоде
/// </summary>
public sealed class WeatherReportQuery : PagedQuery, IDatetimeRange
{
    /// <inheritdoc />
    [FromQuery(Name = "from")]
    public DateTime? From { get; set; }
    
    /// <inheritdoc />
    [FromQuery(Name = "to")]
    public DateTime? To { get; set; }
}