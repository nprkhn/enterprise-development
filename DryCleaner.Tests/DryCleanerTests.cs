using DryCleaner.Domain.Data;
using DryCleaner.Domain.Entities;
using DryCleaner.Shared.Enums;
using Xunit;

namespace DryCleaner.Tests;

/// <summary>
/// Тесты химчистки
/// </summary>
public class DryCleanerTests
{
    /// <summary>
    /// Заказы в обработке, упорядоченные по дате приёма
    /// </summary>
    [Fact]
    public void OrdersInProgress()
    {
        var inProgress = DataSeed.Orders
            .Where(o => o.Status == OrderStatus.InProgress)
            .OrderBy(o => o.AcceptanceDate)
            .ToList();

        Assert.Equal(3, inProgress.Count);
        Assert.Equal(new DateOnly(2026, 3, 1), inProgress[0].AcceptanceDate);
        Assert.Equal(new DateOnly(2026, 3, 5), inProgress[1].AcceptanceDate);
        Assert.Equal(new DateOnly(2026, 3, 10), inProgress[2].AcceptanceDate);
        Assert.All(inProgress, o => Assert.Equal(OrderStatus.InProgress, o.Status));
    }

    /// <summary>
    /// Топ-5 клиентов по числу сданных изделий за период
    /// </summary>
    [Fact]
    public void Top5Clients()
    {
        var from = new DateOnly(2025, 1, 1);
        var to = new DateOnly(2026, 3, 15);

        var top5 = DataSeed.Orders
            .Where(o => o.AcceptanceDate >= from && o.AcceptanceDate <= to)
            .GroupBy(o => o.Costumer)
            .Select(g => new { Costumer = g.Key, Items = g.Count() })
            .OrderByDescending(x => x.Items)
            .ThenBy(x => x.Costumer.LastName)
            .Take(5)
            .ToList();

        Assert.Equal(5, top5.Count);
        Assert.Equal("Евлампьев", top5[0].Costumer.LastName);
        Assert.Equal("Евлампий", top5[0].Costumer.FirstName);
        Assert.Equal("Евлампиевич", top5[0].Costumer.MiddleName);
        Assert.Equal(4, top5[0].Items);
        Assert.Equal(10, top5.Sum(x => x.Items));
    }

    /// <summary>
    /// Клиенты, чьи заказы обрабатывались дольше всего, по ФИО
    /// </summary>
    [Fact]
    public void ClientsWithLongestProcessing()
    {
        var maxCompletionDays = DataSeed.Orders.Max(o => o.CompletionDays);
        var costumers = DataSeed.Orders
            .Where(o => o.CompletionDays == maxCompletionDays)
            .Select(o => o.Costumer)
            .Distinct()
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName)
            .ThenBy(c => c.MiddleName)
            .ToList();

        Assert.Equal(10, maxCompletionDays);
        Assert.Equal(1, costumers.Count);
        Assert.Equal("Вазовский", costumers[0].LastName);
        Assert.Equal("Майк", costumers[0].FirstName);
        Assert.Equal("Петрович", costumers[0].MiddleName);
    }

    /// <summary>
    /// Топ-5 наиболее и наименее популярных категорий за последний год
    /// </summary>
    [Fact]
    public void Top5CategoriesByPopularity()
    {
        var referenceDate = new DateOnly(2026, 3, 15);
        var yearAgo = referenceDate.AddYears(-1);

        var byCategory = DataSeed.Orders
            .Where(o => o.AcceptanceDate >= yearAgo && o.AcceptanceDate <= referenceDate)
            .GroupBy(o => o.Item.Category)
            .Select(g => new { Category = g.Key, Count = g.Count() })
            .ToList();

        var mostPopular = byCategory
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Category.Name)
            .Take(5)
            .ToList();

        var leastPopular = byCategory
            .Where(x => x.Count > 0)
            .OrderBy(x => x.Count)
            .ThenBy(x => x.Category.Name)
            .Take(5)
            .ToList();

        Assert.Equal(5, mostPopular.Count);
        Assert.Equal("Костюм", mostPopular[0].Category.Name);
        Assert.Equal(3, mostPopular[0].Count);
        Assert.Equal(11, mostPopular.Sum(x => x.Count));

        Assert.Equal(5, leastPopular.Count);
        Assert.All(leastPopular.Take(4), x => Assert.Equal(1, x.Count));
        Assert.Equal(6, leastPopular.Sum(x => x.Count));

        var leastNames = leastPopular.Take(4).Select(x => x.Category.Name).ToList();
        Assert.Contains("Брюки", leastNames);
        Assert.Contains("Постельное бельё", leastNames);
        Assert.Contains("Спортивная одежда", leastNames);
        Assert.Contains("Шуба", leastNames);
    }

    /// <summary>
    /// Клиент, потративший наибольшую сумму за всё время
    /// </summary>
    [Fact]
    public void TopSpender()
    {
        var top = DataSeed.Orders
            .GroupBy(o => o.Costumer)
            .Select(g => new
            {
                Costumer = g.Key,
                Total = g.Sum(o => o.Item.Category.Price)
            })
            .OrderByDescending(x => x.Total)
            .ThenBy(x => x.Costumer.LastName)
            .First();

        Assert.Equal("Евлампьев", top.Costumer.LastName);
        Assert.Equal("Евлампий", top.Costumer.FirstName);
        Assert.Equal("Евлампиевич", top.Costumer.MiddleName);
        Assert.Equal(10600, top.Total);
    }
}