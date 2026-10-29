using DryCleaner.Application.Contracts.DTOs;
using DryCleaner.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DryCleaner.Api.Controllers;

/// <summary>
/// HTTP-операции для работы с изделиями
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ItemController(IItemService service, ILogger<ItemController> logger) : ControllerBase
{
    /// <summary>
    /// Получение всех изделий
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        try 
        {
            logger.LogInformation("Запрос на получение всех изделий");
            return Ok(service.GetAll()); 
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при получении изделий");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Получение изделия по идентификатору
    /// </summary>
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        try
        {
            logger.LogInformation("Запрос: Получение изделия по идентификатору");

            var result = service.Get(id);
            if (result is null) return NotFound();
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при получении изделия по идентификатору");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Создание изделия
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] ItemCreateUpdateDto dto)
    {
        try
        {
            logger.LogInformation("Запрос: Создание изделия");

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = service.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
        catch (KeyNotFoundException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при создании изделия");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Обновление изделия
    /// </summary>
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] ItemCreateUpdateDto dto)
    {
        try
        {
            logger.LogInformation("Запрос: Обновление изделия");

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(service.Update(dto, id));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при обновлении изделия");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Удаление изделия
    /// </summary>
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        try
        {
            logger.LogInformation("Запрос: Удаление изделия");

            if (!service.Delete(id)) return NotFound();
            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при удалении изделия");
            return StatusCode(500, "Ошибка сервера");
        }
    }
}