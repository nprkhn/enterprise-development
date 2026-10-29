using DryCleaner.Application.Contracts.DTOs;
using DryCleaner.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DryCleaner.Api.Controllers;

/// <summary>
/// HTTP-операции для работы с категориями изделий
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ItemCategoryController(IItemCategoryService service, ILogger<ItemCategoryController> logger) : ControllerBase
{
    /// <summary>
    /// Получение всех категорий изделий
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        try 
        {
            logger.LogInformation("Запрос: Вывод всех категорий изделий");
            return Ok(service.GetAll()); 
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при получении категорий");
            return StatusCode(500, "Ошибка сервера" );
        }
    }

    /// <summary>
    /// Получение категории изделия по идентификатору
    /// </summary>
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        try
        {
            logger.LogInformation("Запрос: Получение каегории по идентификатору");

            var result = service.Get(id);
            if (result is null) return NotFound();
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при получении категории по идентификатору");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Создание категории изделия
    /// </summary>
    [HttpPost]
    public IActionResult Create([FromBody] ItemCategoryCreateUpdateDto dto)
    {
        try
        {
            logger.LogInformation("Запрос: Создание категории");

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = service.Create(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при создании категории");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Обновление категории изделия
    /// </summary>
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] ItemCategoryCreateUpdateDto dto)
    {
        try
        {
            logger.LogInformation("Запрос: Обновление категории");

            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(service.Update(dto, id));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при обновлении категории");
            return StatusCode(500, "Ошибка сервера");
        }
    }

    /// <summary>
    /// Удаление категории изделия
    /// </summary>
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        try
        {
            logger.LogInformation("Запрос: Удаление категории");

            if (!service.Delete(id)) return NotFound();
            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при удалении категории");
            return StatusCode(500, "Ошибка сервера");
        }
    }
}