using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WeatherExcelStorage.Core.Data;

/// <summary>
///     Design-time фабрика для <see cref="DatabaseContext" />
/// </summary>
internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    /// <inheritdoc />
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
        
        // Креды по умолчанию для локальной БД
        optionsBuilder
            .UseNpgsql(
                "Server=127.0.0.1;User Id=postgres;Port=5432;Database=weather;Password=postgres;Include Error Detail=true",
                options => { options.MigrationsHistoryTable("schema_migrations"); }
            );

        return new DatabaseContext(optionsBuilder.Options);
    }
}
