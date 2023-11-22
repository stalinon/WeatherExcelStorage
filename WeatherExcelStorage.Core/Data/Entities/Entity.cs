using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WeatherExcelStorage.Core.Data.Entities;

/// <summary>
///     Базовый класс для сущностей
/// </summary>
[PrimaryKey(nameof(Id))]
[Index(nameof(CreatedAt), nameof(UpdatedAt))]
public abstract class Entity
{
    /// <summary>
    ///     ID
    /// </summary>
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    ///     Дата и время создания
    /// </summary>
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     Дата и время последнего обновления
    /// </summary>
    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}