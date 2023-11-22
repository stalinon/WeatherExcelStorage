using Microsoft.AspNetCore.Mvc;
using WeatherExcelStorage.Api.Enums;

namespace WeatherExcelStorage.Api.Models.Requests;

/// <summary>
///     Пагинированный запрос
/// </summary>
public class PagedQuery
{
    /// <summary>
    ///     Пропуск
    /// </summary>
    [FromQuery(Name = "skip")]
    public int Skip { get; set; } = 0;

    /// <summary>
    ///     Максимальное количество записей
    /// </summary>
    [FromQuery(Name = "max")]
    public int Max { get; set; } = 20;

    /// <summary>
    ///     Сортировка
    /// </summary>
    [FromQuery(Name = "sort")]
    public ColumnSortType SortType { get; set; }
}