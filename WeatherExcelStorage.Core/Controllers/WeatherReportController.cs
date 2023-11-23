using Microsoft.AspNetCore.Mvc;
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
    
    /// <summary>
    ///     Главная страница
    /// </summary>
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }
    
    /// <summary>
    ///     Просмотр архивов
    /// </summary>
    [Route("/reports")]
    public async Task<IActionResult> ListView(WeatherReportQuery query)
    {
        var reports = await _reportService.ListAsync(query);
        return View("ListView", reports);
    }
    
    /// <summary>
    ///     Загрузка архивов
    /// </summary>
    [HttpPost]
    [Route("/upload")]
    public async Task<IActionResult> UploadFiles(List<IFormFile> files)
    {
        foreach (var file in files)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
        
            var fileBytes = ms.ToArray();

            try
            {
                await _reportService.UploadExcelReportAsync(fileBytes);
            }
            catch (InvalidOperationException ex)
            {
                return View("UploadFile", ex.Message);
            }
        }

        return View("UploadFile");
    }
    
    /// <summary>
    ///     Загрузка архивов
    /// </summary>
    [HttpGet]
    [Route("/upload")]
    public IActionResult Upload()
    {
        return View("UploadFile");
    }
}