using DryCleaner.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DryCleaner.Api.Controllers;

/// <summary>
/// API для получения аналитики
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AnalyticsController(IAnalyticsService analyticsService, ILogger<AnalyticsController> logger) : ControllerBase
{
    /// <summary>
    /// Получает заказы, находящиеся в обработке
    /// </summary>
    [HttpGet("in-progress-orders")]
    public IActionResult GetInProgressOrders()
    {
        try
        {
            logger.LogInformation("Запрос на получение заказов в обработке");
            return Ok(analyticsService.GetOrdersInProgress());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка в обработке");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Получает ТОП-5 клиентов по числу сданных изделий за выбранный период
    /// </summary>
    [HttpGet("top-5-customers")]
    public IActionResult GetTop5Customers([FromQuery] DateOnly start, [FromQuery] DateOnly end)
    {
        try
        {
            logger.LogInformation("Запрос: Топ-5 клиентов за период");
            if (start == default) start = new DateOnly(2025, 1, 1);
            if (end == default) end = new DateOnly(2026, 3, 15);

            return Ok(analyticsService.GetTop5CustomersByItems(start, end));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка в аналитике");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Получает клиентов с наибольшим временем обработки заказов
    /// </summary>
    [HttpGet("longest-processing")]
    public IActionResult GetLongestProcessing()
    {
        try
        {
            logger.LogInformation("Запрос: Клиенты с наибольшим временем обработки заказов");
            return Ok(analyticsService.GetCustomersWithLongestProcessing());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка в аналитике");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Получает наиболее популярные категории
    /// </summary>
    [HttpGet("popular-categories")]
    public IActionResult GetPopularCategories()
    {
        try
        {
            logger.LogInformation("Запрос: Наиболее популярные категории");
            return Ok(analyticsService.GetTop5PopularCategories());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка в аналитике");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Получает клиента с наибольшими тратами
    /// </summary>
    [HttpGet("top-spender")]
    public IActionResult GetTopSpender()
    {
        try
        {
            logger.LogInformation("Запрос: Клиент с наибольшими тратами");
            var result = analyticsService.GetCustomerWithMaxTotalSpent();
            if (result is null) return NotFound("Клиент не найден");
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка в аналитике");
            return StatusCode(500, "Ошибка сервера");
        }
    }
}