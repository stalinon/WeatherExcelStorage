using System.Linq.Expressions;
using WeatherExcelStorage.Api.Enums;

namespace WeatherExcelStorage.Core.Data.Repositories;

/// <summary>
///     Репозиторий только для чтения
/// </summary>
public interface IReadOnlyRepository<T> where T : class
{
    /// <summary>
    ///     Создать произвольный запрос на получение сущностей из БД
    /// </summary>
    IQueryable<T> CreateQuery(
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? sort = null,
        ColumnSortType sortDirection = ColumnSortType.Ascending);

    /// <summary>
    ///     Получить объекты согласно фильтру
    /// </summary>
    Task<T[]> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? sort = null,
        ColumnSortType sortDirection = ColumnSortType.Ascending,
        CancellationToken cancellationToken = default);

    /// <summary>
    ///     Получить объект согласно фильтру
    /// </summary>
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Возвращает список неотслеживаемых сущностей
    /// </summary>
    IQueryable<T> NoTracking();
}
