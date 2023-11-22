using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Shopium.App.Core.Data;

/// <summary>
///     Design-time фабрика для <see cref="DatabaseContext" />
/// </summary>
[UsedImplicitly]
internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    /// <inheritdoc />
    public DatabaseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
        optionsBuilder
            .UseNpgsql(
                "Host=localhost;Port=5432;Database=shopium;User Id=postgres;Password=postgres",
                options => { options.MigrationsHistoryTable("schema_migrations"); }
            );

        return new DatabaseContext(optionsBuilder.Options);
    }
}
