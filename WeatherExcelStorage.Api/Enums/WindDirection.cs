using WeatherExcelStorage.Core.Attributes;

namespace WeatherExcelStorage.Core.Data.Enums;

/// <summary>
///     Направление ветра
/// </summary>
public enum WindDirection
{
    /// <summary>
    ///     Штиль
    /// </summary>
    [Name("штиль")]
    None = 0,
    
    /// <summary>
    ///     Запад
    /// </summary>
    [Name("З")]
    West = 1,
    
    /// <summary>
    ///     Восток
    /// </summary>
    [Name("В")]
    East = 2,
    
    /// <summary>
    ///     Север
    /// </summary>
    [Name("С")]
    North = 3,
    
    /// <summary>
    ///     Юг
    /// </summary>
    [Name("Ю")]
    South = 4,
    
    /// <summary>
    ///     Юго-запад
    /// </summary>
    [Name("ЮЗ")]
    SouthWest = 5,
    
    /// <summary>
    ///     Юго-восток
    /// </summary>
    [Name("ЮВ")]
    SouthEast = 6,
    
    /// <summary>
    ///     Северо-запад
    /// </summary>
    [Name("СЗ")]
    NorthWest = 7,
    
    /// <summary>
    ///     Северо-восток
    /// </summary>
    [Name("СВ")]
    NorthEast = 8,
}