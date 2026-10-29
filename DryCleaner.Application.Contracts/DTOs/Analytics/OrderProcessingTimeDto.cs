namespace DryCleaner.Application.Contracts.DTOs.Analytics;

/// <summary>
/// Информация о времени обработки заказа
/// </summary>
/// <param name="OrderId">Идентификатор заказа</param>
/// <param name="CustomerName">ФИО клиента</param>
/// <param name="CompletionDays">Время обработки заказа</param>
public record OrderProcessingTimeDto(
    int OrderId,
    string CustomerName,
    int CompletionDays);