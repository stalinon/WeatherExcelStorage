namespace WeatherExcelStorage.Api.Models.Requests;

/// <summary>
///     Интервал дат
/// </summary>
public interface IDatetimeRange
{
    /// <summary>
    ///     От
    /// </summary>
    public DateTime? From { get; }

    /// <summary>
    ///     До
    /// </summary>
    public DateTime? To { get; }
}