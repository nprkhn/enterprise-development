using DryCleaner.Application.Contracts.DTOs;
using DryCleaner.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DryCleaner.Api.Controllers;

/// <summary>
/// HTTP-операции для работы с клиентами
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService service, ILogger<CustomerController> logger) : ControllerBase
{
    /// <summary>
    /// Получение списка всех клиентов
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            logger.LogInformation("Запрос всех клиентов");
            return Ok(service.GetAll());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при получении клиентов");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Получение клиента по идентификатору
    /// </summary>
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        try
        {
            logger.LogInformation("Запрос клиента по идентификатору");

            var result = service.Get(id);
            if (result is null)
            {
                logger.LogWarning("Клиент с указанным идентификатором не найден");
                return NotFound("Клиент с указанным идентификатором не найден");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при получении клиента по указанному идентификатору");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Создание клиента
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] CustomerCreateUpdateDto dto)
    {
        try
        {
            logger.LogInformation("Запрос на создание клиента");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = service.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при создании клиента");
            return StatusCode(500, "Ошибка сервера" );
        }
    }

    /// <summary>
    /// Обновление клиента
    /// </summary>
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] CustomerCreateUpdateDto dto)
    {
        try
        {
            logger.LogInformation("Запрос на обновление клиента");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = service.Update(dto, id);
            return Ok(updated);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogWarning(ex, "Клиент по указанному идентификатору не найден");
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при обновлении клиента по указанному идентификатору");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Удаление клиента
    /// </summary>
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        try
        {
            logger.LogInformation("Запрос на удаление клиента");

            var deleted = service.Delete(id);
            if (!deleted) return NotFound("Клиент с указанным идентификатором не найден");
            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при удалении клиента");
            return StatusCode(500, "Ошибка сервера");
        }
    }
}