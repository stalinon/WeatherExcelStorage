using Microsoft.AspNetCore.Mvc;
using WeatherExcelStorage.Api.Models;
using WeatherExcelStorage.Api.Models.Requests;
using WeatherExcelStorage.Core.Domain.Services;

namespace WeatherExcelStorage.Core.Controllers;

/// <summary>
///     Контроллер отчетов по погоде
/// </summary>
public sealed class WeatherReportController : Controller
{
    private readonly IWeatherReportService _reportService;

    /// <inheritdoc cref="WeatherReportController" />
    public WeatherReportController(IWeatherReportService reportService)
    {
        _reportService = reportService;
    }
    
    #region GET api/reports

    /// <summary>
    ///     Получить список
    /// </summary>
    [
        HttpGet("~/api/reports"),
        ProducesResponseType(typeof(PagedList<WeatherReport>), 200)
    ]
    public async Task<IActionResult> List(
        [FromQuery] WeatherReportQuery query,
        CancellationToken cancellationToken)
    {
        var reports = await _reportService.ListAsync(query, cancellationToken);

        return Ok(reports);
    }

    #endregion
    
    #region POST api/reports

    /// <summary>
    ///     Загрузить файл Excel
    /// </summary>
    [
        HttpPost("~/api/reports"),
        ProducesResponseType(200),
        ProducesResponseType(400)
    ]
    public async Task<IActionResult> Upload(
        IFormFile file,
        CancellationToken cancellationToken)
    {
        if (file.Length <= 0)
        {
            return BadRequest();
        }
        
        using var ms = new MemoryStream();
        await file.CopyToAsync(ms, cancellationToken);
        
        var fileBytes = ms.ToArray();
        await _reportService.UploadExcelReportAsync(fileBytes, cancellationToken);

        return Ok();

    }

    #endregion
}