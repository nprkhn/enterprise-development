using DryCleaner.Application.Contracts.DTOs.Analytics;

namespace DryCleaner.Application.Contracts.Interfaces;

/// <summary>
/// ќпредел€ет операции получени€ аналитической информации
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    /// ѕолучает заказы в обработке, упор€доченные по дате приема
    /// </summary>
    IList<OrderInProgressDto> GetOrdersInProgress();

    /// <summary>
    /// ѕолучает топ-5 клиентов по числу сданных изделий за выбранный период
    /// </summary>
    IList<CustomerOrderCountDto> GetTop5CustomersByItems(DateOnly periodStart, DateOnly periodEnd);

    /// <summary>
    /// ѕолучает клиентов, чьи заказы обрабатывались дольше всего
    /// </summary>
    IList<OrderProcessingTimeDto> GetCustomersWithLongestProcessing();

    /// <summary>
    /// ѕолучает топ-5 попул€рных и непопул€рных категорий изделий
    /// </summary>
    IList<CategoryPopularityDto> GetTop5PopularCategories();

    /// <summary>
    /// ѕолучает клиента с наибольшей суммой заказов
    /// </summary>
    TotalSpentCustomerDto? GetCustomerWithMaxTotalSpent();
}