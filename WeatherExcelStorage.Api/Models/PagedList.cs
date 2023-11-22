using System.Text.Json.Serialization;

namespace WeatherExcelStorage.Api.Models;

/// <summary>
///     Пагинированный список
/// </summary>
public sealed class PagedList<TModel>
    where TModel : class
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
}