namespace WeatherExcelStorage.Core;

/// <summary>
///     Точка входа
/// </summary>
// ReSharper disable once ClassNeverInstantiated.Global
public sealed class Program
{
    /// <inheritdoc cref="Program" />
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    /// <summary>
    ///     Создать строитель <see cref="IHost" />
    /// </summary>
    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.ConfigureKestrel(
                    serverOptions =>
                    {
                        serverOptions.AllowSynchronousIO = true;
                        serverOptions.ListenAnyIP(5005);
                    });
            });
}