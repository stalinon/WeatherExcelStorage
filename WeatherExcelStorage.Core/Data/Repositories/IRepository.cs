namespace WeatherExcelStorage.Core.Data.Repositories;

/// <summary>
///     Базовый репозиторий
/// </summary>
public interface IRepository<T> : IReadOnlyRepository<T> where T : class
{
    /// <summary>
    ///     Добавляет <paramref name="entity"/> в контекст
    /// </summary>
    Task AddAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Добавляет <paramref name="entities"/> в контекст
    /// </summary>
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Удаляет <paramref name="entity"/> из контекста
    /// </summary>
    void Remove(T entity);

    /// <summary>
    ///     Удаляет <paramref name="entities"/> из контекста
    /// </summary>
    void RemoveRange(T[] entities);

    /// <summary>
    ///     Сохранение контекста
    /// </summary>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}