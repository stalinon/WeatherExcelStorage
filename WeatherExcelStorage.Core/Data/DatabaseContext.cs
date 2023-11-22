using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using WeatherExcelStorage.Core.Data.Entities;

namespace WeatherExcelStorage.Core.Data;

/// <summary>
///     Контекст БД
/// </summary>
public sealed class DatabaseContext : DbContext
{
    /// <inheritdoc cref="DatabaseContext" />
    public DatabaseContext(DbContextOptions options) : base(options)
    { }

    /// <summary>
    ///     Таблица отчетов по погоде
    /// </summary>
    public DbSet<WeatherReportEntity> WeatherReports => Set<WeatherReportEntity>();

    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // SEE: Unhandled exception. System.InvalidOperationException:
        // An error was generated for warning 'Microsoft.EntityFrameworkCore.Model.Validation.CollectionWithoutComparer':
        // The property 'ProductVariantEntity.Key' is a collection or enumeration type with a value converter but with no value comparer.
        // Set a value comparer to ensure the collection/enumeration elements are compared correctly.
        // This exception can be suppressed or logged by passing event ID 'CoreEventId.CollectionWithoutComparer'
        // to the 'ConfigureWarnings' method in 'DbContext.OnConfiguring' or 'AddDbContext'.
        optionsBuilder.ConfigureWarnings(_ => _.Ignore(CoreEventId.CollectionWithoutComparer));
    }
}