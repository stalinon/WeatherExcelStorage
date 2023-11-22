namespace WeatherExcelStorage.Api.Attributes;

/// <summary>
///     Атрибут для выставления названия
///     элементам перечисления
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public sealed class NameAttribute : Attribute
{
    /// <summary>
    ///     Название
    /// </summary>
    public string Name { get; }

    /// <inheritdoc cref="NameAttribute" />
    public NameAttribute(string name)
    {
        Name = name;
    }
}