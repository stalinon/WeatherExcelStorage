using System.Text.Json.Serialization;
using WeatherExcelStorage.Api.Models.Requests;

namespace WeatherExcelStorage.Api.Models;

/// <summary>
///     Пагинированный список
/// </summary>
public sealed class PagedList<TModel, TPagedRequest>
    where TModel : class
    where TPagedRequest : PagedQuery
{
    /// <summary>
    ///     Элементы
    /// </summary>
    [JsonPropertyName("items")]
    public TModel[] Items { get; set; } = Array.Empty<TModel>();

    /// <summary>
    ///     Общее количество
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    ///     Запрос
    /// </summary>
    [JsonPropertyName("request")]
    public TPagedRequest Request { get; set; }
}