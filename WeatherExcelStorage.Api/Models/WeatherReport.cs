using System.Text.Json.Serialization;
using WeatherExcelStorage.Api.Enums;

namespace WeatherExcelStorage.Api.Models;

/// <summary>
///     Модель отчета по погоде
/// </summary>
public class WeatherReport
{    
    /// <summary>
    ///     ID
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    ///     Дата и время создания
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     Дата и время последнего обновления
    /// </summary>
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    
    /// <summary>
    ///     Дата и время отчета
    /// </summary>
    [JsonPropertyName("datetime")]
    public DateTime DateTime { get; set; }

    /// <summary>
    ///     Температура воздуха
    /// </summary>
    [JsonPropertyName("temperature")]
    public decimal AirTemperature { get; set; }

    /// <summary>
    ///     Облачность
    /// </summary>
    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    /// <summary>
    ///     Точка росы
    /// </summary>
    [JsonPropertyName("dew")]
    public decimal DewPoint { get; set; }

    /// <summary>
    ///     Атмосферное давление
    /// </summary>
    [JsonPropertyName("pressure")]
    public int AirPressure { get; set; }

    /// <summary>
    ///     Направление ветра
    /// </summary>
    [JsonPropertyName("wind_direction")]
    public WindDirection[] WindDirection { get; set; } = Array.Empty<WindDirection>();

    /// <summary>
    ///     Скорость ветра
    /// </summary>
    [JsonPropertyName("wind_speed")]
    public int WindSpeed { get; set; }

    /// <summary>
    ///     Облачность
    /// </summary>
    [JsonPropertyName("overcast")]
    public int? Overcast { get; set; }

    /// <summary>
    ///     Нижняя граница облачности
    /// </summary>
    [JsonPropertyName("low_overcast_point")]
    public int LowOvercastPoint { get; set; }

    /// <summary>
    ///     Горизонтальная видимость
    /// </summary>
    [JsonPropertyName("horizontal_sight")]
    public int? HorizontalSight { get; set; }

    /// <summary>
    ///     Погодные условия, краткое описание
    /// </summary>
    [JsonPropertyName("description")]
    public string? WeatherConditions { get; set; }
}