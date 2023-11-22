using Npoi.Mapper.Attributes;

namespace WeatherExcelStorage.Core.Domain.Models;

/// <summary>
///     Болванка строки из файла Excel
/// </summary>
internal sealed class WeatherReportRow
{
    /// <summary>
    ///     Дата отчета
    /// </summary>
    [Column(0)]
    public string Date { get; set; } = default!;

    /// <summary>
    ///     Bремя отчета
    /// </summary>
    [Column(1)]
    public string Time { get; set; } = default!;

    /// <summary>
    ///     Температура воздуха
    /// </summary>
    [Column(2)]
    public decimal AirTemperature { get; set; }

    /// <summary>
    ///     Облачность
    /// </summary>
    [Column(3)]
    public int Humidity { get; set; }

    /// <summary>
    ///     Точка росы
    /// </summary>
    [Column(4)]
    public decimal DewPoint { get; set; }

    /// <summary>
    ///     Атмосферное давление
    /// </summary>
    [Column(5)]
    public int AirPressure { get; set; }

    /// <summary>
    ///     Направление ветра
    /// </summary>
    [Column(6)]
    public string WindDirection { get; set; } = default!;

    /// <summary>
    ///     Скорость ветра
    /// </summary>
    [Column(7)]
    public int WindSpeed { get; set; }

    /// <summary>
    ///     Облачность
    /// </summary>
    [Column(8)]
    public int? Overcast { get; set; }

    /// <summary>
    ///     Нижняя граница облачности
    /// </summary>
    [Column(9)]
    public int LowOvercastPoint { get; set; }

    /// <summary>
    ///     Горизонтальная видимость
    /// </summary>
    [Column(10)]
    public int? HorizontalSight { get; set; }

    /// <summary>
    ///     Погодные условия, краткое описание
    /// </summary>
    [Column(11)]
    public string? WeatherConditions { get; set; }
}