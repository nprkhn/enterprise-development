using DryCleaner.Domain.Data;
using DryCleaner.Domain.Entities;
using DryCleaner.Domain.Enums;
using Xunit;

namespace DryCleaner.Tests;

/// <summary>
/// Тесты химчистки
/// </summary>
public class Tests
{
    private readonly List<Client> _clients;
    private readonly List<Item> _items;
    private readonly List<Order> _orders;

    public Tests()
    {
        _clients = DataSeed.Clients();
        _items = DataSeed.Items();
        _orders = DataSeed.Orders();
    }

    /// <summary>
    /// Заказы в обработке, упорядоченные по дате приёма
    /// </summary>
    [Fact]
    public void OrdersInProgress()
    {
        var inProgress = _orders
            .Where(o => o.Status == OrderStatus.InProgress)
            .OrderBy(o => o.AcceptanceDate)
            .ToList();

        Assert.Equal(3, inProgress.Count);
        Assert.Equal(new DateTime(2026, 3, 1), inProgress[0].AcceptanceDate);
        Assert.Equal(new DateTime(2026, 3, 5), inProgress[1].AcceptanceDate);
        Assert.Equal(new DateTime(2026, 3, 10), inProgress[2].AcceptanceDate);
        Assert.All(inProgress, o => Assert.Equal(OrderStatus.InProgress, o.Status));
    }

    /// <summary>
    /// Топ-5 клиентов по числу сданных изделий за период
    /// </summary>
    [Fact]
    public void Top5Clients()
    {
        var from = new DateTime(2025, 1, 1);
        var to = new DateTime(2026, 3, 15);

        var top5 = _orders
            .Where(o => o.AcceptanceDate >= from && o.AcceptanceDate <= to)
            .GroupBy(o => o.Client)
            .Select(g => new { Client = g.Key, Items = g.Count() })
            .OrderByDescending(x => x.Items)
            .ThenBy(x => x.Client.FullName)
            .Take(5)
            .ToList();

        Assert.Equal(5, top5.Count);
        Assert.Equal("Евлампьев Евлампий Евлампиевич", top5[0].Client.FullName);
        Assert.Equal(4, top5[0].Items);
        Assert.Equal(10, top5.Sum(x => x.Items));
    }

    /// <summary>
    /// Клиенты, чьи заказы обрабатывались дольше всего, по ФИО
    /// </summary>
    [Fact]
    public void ClientsWithLongestProcessing()
    {
        var longest = _orders
            .GroupBy(o => o.Client)
            .Select(g => new
            {
                Client = g.Key,
                MaxDays = g.Max(o => o.CompletionDays)
            })
            .OrderByDescending(x => x.MaxDays)
            .ThenBy(x => x.Client.FullName)
            .Take(5)
            .ToList();

        Assert.Equal(5, longest.Count);
        Assert.Equal("Вазовский Майк Петрович", longest[0].Client.FullName);
        Assert.Equal(10, longest[0].MaxDays);
        Assert.Equal("Сергеев Александр Сильвестрович", longest[1].Client.FullName);
        Assert.Equal(7, longest[1].MaxDays);
    }

    /// <summary>
    /// Топ-5 наиболее и наименее популярных категорий за последний год
    /// </summary>
    [Fact]
    public void Top5CategoriesByPopularity()
    {
        var referenceDate = new DateTime(2026, 3, 15);
        var yearAgo = referenceDate.AddYears(-1);

        var byCategory = _orders
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
        Assert.Contains("Постельное белье", leastNames);
        Assert.Contains("Спортивная одежда", leastNames);
        Assert.Contains("Шуба", leastNames);
    }

    /// <summary>
    /// Клиент, потративший наибольшую сумму за всё время
    /// </summary>
    [Fact]
    public void TopSpender()
    {
        var top = _orders
            .GroupBy(o => o.Client)
            .Select(g => new
            {
                Client = g.Key,
                Total = g.Sum(o => o.Item.Category.Price)
            })
            .OrderByDescending(x => x.Total)
            .ThenBy(x => x.Client.FullName)
            .First();

        Assert.Equal("Евлампьев Евлампий Евлампиевич", top.Client.FullName);
        Assert.Equal(10600, top.Total);
    }
}