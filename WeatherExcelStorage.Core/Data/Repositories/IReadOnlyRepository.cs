using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Scraper.Common.Enums;

namespace Scraper.Common.Database;

/// <summary>
/// Репозиторий только для чтения
/// </summary>
public interface IReadOnlyRepository<T> where T : class
{
    /// <summary>
    /// Создать произвольный запрос на получение сущностей из БД
    /// </summary>
    IQueryable<T> CreateQuery(Expression<Func<T, bool>>? filter = null);

    /// <summary>
    /// Получить объекты согласно фильтру
    /// </summary>
    Task<T[]> GetAllAsync(
        Expression<Func<T, bool>>? filter = null,
        Expression<Func<T, object>>? sort = null,
        ColumnSortType sortDirection = ColumnSortType.Ascending,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить объект согласно фильтру
    /// </summary>
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Возвращает список неотслеживаемых сущностей
    /// </summary>
    IQueryable<T> NoTracking();
}
