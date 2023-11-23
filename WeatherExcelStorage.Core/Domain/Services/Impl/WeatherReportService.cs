using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using Npoi.Mapper;
using NPOI.XSSF.UserModel;
using WeatherExcelStorage.Api.Attributes;
using WeatherExcelStorage.Api.Enums;
using WeatherExcelStorage.Api.Models;
using WeatherExcelStorage.Api.Models.Requests;
using WeatherExcelStorage.Core.Data.Entities;
using WeatherExcelStorage.Core.Data.Repositories;
using WeatherExcelStorage.Core.Domain.Models;

namespace WeatherExcelStorage.Core.Domain.Services.Impl;

/// <inheritdoc cref="IWeatherReportService" />
internal sealed class WeatherReportService : IWeatherReportService
{
    private readonly IWeatherReportRepository _repository;
    private static readonly Dictionary<string, WindDirection> WindDirections 
        = Enum.GetValues<WindDirection>()
        .ToDictionary(
            kv => kv.GetAttributeOfType<NameAttribute>().Name,
            kv => kv);

    /// <inheritdoc cref="WeatherReportService" />
    public WeatherReportService(IWeatherReportRepository repository)
    {
        _repository = repository;
    }
    
    /// <inheritdoc />
    public async Task<PagedList<WeatherReport, WeatherReportQuery>> ListAsync(
        WeatherReportQuery query, CancellationToken cancellationToken = default)
    {
        var queryable = CreateReportQuery(query);

        var total = await queryable.CountAsync(cancellationToken);
        var items = await queryable.Select(e => MapFromEntity(e))
            .Skip(query.Skip)
            .Take(query.Max)
            .ToArrayAsync(cancellationToken);

        query.From ??= await queryable.MinAsync(e => e.DateTime, cancellationToken);
        query.To ??= await queryable.MaxAsync(e => e.DateTime, cancellationToken);
        return new()
        {
            Items = items,
            Total = total,
            Request = query
        };

        IQueryable<WeatherReportEntity> CreateReportQuery(WeatherReportQuery weatherReportQuery)
        {
            var reportQuery = _repository.CreateQuery();

            if (weatherReportQuery.From != null)
            {
                var from = DateTime.SpecifyKind(weatherReportQuery.From.Value, DateTimeKind.Utc);
                reportQuery = reportQuery.Where(e => e.DateTime >= from);
            }

            if (weatherReportQuery.To != null)
            {
                var to = DateTime.SpecifyKind(weatherReportQuery.To.Value, DateTimeKind.Utc);
                reportQuery = reportQuery.Where(e => e.DateTime <= to);
            }

            reportQuery = weatherReportQuery.SortType switch
            {
                ColumnSortType.Ascending => reportQuery.OrderBy(e => e.DateTime),
                ColumnSortType.Descending => reportQuery.OrderByDescending(e => e.DateTime),
                _ => throw new ArgumentOutOfRangeException()
            };
            return reportQuery;
        }
    }

    /// <inheritdoc />
    public async Task UploadExcelReportAsync(
        byte[] bytes, CancellationToken cancellationToken = default)
    {
        try
        {
            await using var stream = new MemoryStream(bytes);
            var workbook = new XSSFWorkbook(stream);

            var reportList = ExtractWeatherReportsFromWorkBook(workbook);

            await _repository.AddRangeAsync(reportList.Select(MapToEntity), cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            throw new InvalidOperationException(
                "Невозможно завершить сохранение файлов. Проверьте их валидность, либо убедитесь, что они не были загружены ранее.");
        }
    }

    private static List<WeatherReportRow> ExtractWeatherReportsFromWorkBook(XSSFWorkbook workbook)
    {
        var mapper = new Mapper(workbook)
        {
            HasHeader = true,
            FirstRowIndex = 5
        };
        
        var reportList = new List<WeatherReportRow>();
        for (var i = 0; i < workbook.NumberOfSheets; i++)
        {
            var reports = mapper.Take<WeatherReportRow>(i)
                .Select(r => r.Value)
                .ToArray();

            reportList.AddRange(reports);
        }

        return reportList;
    }

    private static WeatherReport MapFromEntity(WeatherReportEntity entity)
    {
        return new()
        {
            Id = entity.Id,
            AirPressure = entity.AirPressure,
            AirTemperature = entity.AirTemperature,
            CreatedAt = entity.CreatedAt,
            DateTime = entity.DateTime,
            DewPoint = entity.DewPoint,
            HorizontalSight = entity.HorizontalSight,
            Humidity = entity.Humidity,
            LowOvercastPoint = entity.LowOvercastPoint,
            Overcast = entity.Overcast,
            UpdatedAt = entity.UpdatedAt,
            WeatherConditions = entity.WeatherConditions,
            WindDirection = entity.WindDirection,
            WindSpeed = entity.WindSpeed
        };
    }
    
    private WeatherReportEntity MapToEntity(WeatherReportRow model)
    {
        const string delimiter = ",";
        
        var entity = new WeatherReportEntity()
        {
            AirPressure = model.AirPressure,
            AirTemperature = model.AirTemperature,
            DewPoint = model.DewPoint,
            HorizontalSight = model.HorizontalSight,
            Humidity = model.Humidity,
            LowOvercastPoint = model.LowOvercastPoint,
            Overcast = model.Overcast,
            WeatherConditions = model.WeatherConditions,
            WindSpeed = model.WindSpeed,
            UpdatedAt = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow
        };

        var windDirections = model.WindDirection
            .Split(delimiter)
            .Where(s => !string.IsNullOrEmpty(s.Trim()))
            .Select(s => WindDirections[s.Trim()])
            .ToArray();

        entity.WindDirection = windDirections;

        var date = DateOnly.Parse(model.Date);
        var time = TimeOnly.Parse(model.Time);

        entity.DateTime = date.ToDateTime(time, DateTimeKind.Utc);

        return entity;
    }
}