using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WeatherExcelStorage.Api.Enums;

namespace WeatherExcelStorage.Core.Data.Entities;

/// <summary>
///     Таблица отчетов по погоде
/// </summary>
[Table("reports")]
[Index(nameof(DateTime), IsUnique = true)]
public sealed class WeatherReportEntity : Entity
{
    /// <summary>
    ///     Дата и время отчета
    /// </summary>
    [Column("datetime")]
    public DateTime DateTime { get; set; }

    /// <summary>
    ///     Температура воздуха
    /// </summary>
    [Column("temperature")]
    public decimal AirTemperature { get; set; }

    /// <summary>
    ///     Облачность
    /// </summary>
    [Column("humidity")]
    public int Humidity { get; set; }

    /// <summary>
    ///     Точка росы
    /// </summary>
    [Column("dew")]
    public decimal DewPoint { get; set; }

    /// <summary>
    ///     Атмосферное давление
    /// </summary>
    [Column("pressure")]
    public int AirPressure { get; set; }

    /// <summary>
    ///     Направление ветра
    /// </summary>
    [Column("wind_direction")]
    public WindDirection[] WindDirection { get; set; } = Array.Empty<WindDirection>();

    /// <summary>
    ///     Скорость ветра
    /// </summary>
    [Column("wind_speed")]
    public int WindSpeed { get; set; }

    /// <summary>
    ///     Облачность
    /// </summary>
    [Column("overcast")]
    public int? Overcast { get; set; }

    /// <summary>
    ///     Нижняя граница облачности
    /// </summary>
    [Column("low_overcast_point")]
    public int LowOvercastPoint { get; set; }

    /// <summary>
    ///     Горизонтальная видимость
    /// </summary>
    [Column("horizontal_sight")]
    public int? HorizontalSight { get; set; }

    /// <summary>
    ///     Погодные условия, краткое описание
    /// </summary>
    [Column("description")]
    public string? WeatherConditions { get; set; }
}