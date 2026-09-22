using DryCleaner.Domain.Entities;
using DryCleaner.Domain.Enums;

namespace DryCleaner.Domain.Data;

/// <summary>
/// Тестовые данные химчистки
/// </summary>
public static class DataSeed
{
    /// <summary>Категории изделий</summary>
    public static List<ItemCategory> Categories() => new()
    {
        new ItemCategory { Name = "Верхняя одежда", RecommendedCleaning = CleaningType.DryCleaning, Price = 1500 },
        new ItemCategory { Name = "Пальто", RecommendedCleaning = CleaningType.DryCleaning, Price = 2000 },
        new ItemCategory { Name = "Платье", RecommendedCleaning = CleaningType.DryCleaning, Price = 1200 },
        new ItemCategory { Name = "Костюм", RecommendedCleaning = CleaningType.DryCleaning, Price = 1800 },
        new ItemCategory { Name = "Рубашка", RecommendedCleaning = CleaningType.Ironing, Price = 500  },
        new ItemCategory { Name = "Брюки", RecommendedCleaning = CleaningType.Ironing, Price = 800  },
        new ItemCategory { Name = "Постельное белье", RecommendedCleaning = CleaningType.AquaCleaning, Price = 700  },
        new ItemCategory { Name = "Спортивная одежда", RecommendedCleaning = CleaningType.WetCleaning, Price = 600  },
        new ItemCategory { Name = "Куртка", RecommendedCleaning = CleaningType.DryCleaning, Price = 1700 },
        new ItemCategory { Name = "Шуба", RecommendedCleaning = CleaningType.DryCleaning, Price = 5000 },
    };

    /// <summary>Список изделий</summary>
    public static List<Item> Items()
    {
        var categories = Categories();
        return new()
        {
            new Item { Name = "Пальто", Category = categories[1], Material = "Шерсть" },
            new Item { Name = "Пиджак", Category = categories[3], Material = "Хлопок" },
            new Item { Name = "Платье свадебное", Category = categories[2], Material = "Шёлк" },
            new Item { Name = "Рубашка в клеточку", Category = categories[4], Material = "Хлопок" },
            new Item { Name = "Брюки замшевые", Category = categories[5], Material = "Шерсть" },
            new Item { Name = "Куртка", Category = categories[8], Material = "Кожа" },
            new Item { Name = "Шуба норковая", Category = categories[9], Material = "Мех" },
            new Item { Name = "Костюм тройка", Category = categories[3], Material = "Шерсть" },
            new Item { Name = "Футбольная форма", Category = categories[7], Material = "Синтетика" },
            new Item { Name = "Постельное бельё", Category = categories[6], Material = "Хлопок" },
        };
    }

    /// <summary>Список клиентов</summary>
    public static List<Client> Clients() => new()
    {
        new Client { FullName = "Евлампьев Евлампий Евлампиевич", PhoneNumber = "+79001112233" },
        new Client { FullName = "Сергеев Александр Сильвестрович", PhoneNumber = "+79000000000" },
        new Client { FullName = "Сергеев Александр Александрович", PhoneNumber = "+79000000001" },
        new Client { FullName = "Баринов Виктор Петрович", PhoneNumber = "+78005553535" },
        new Client { FullName = "Уолтер Хартвелл Уайт", PhoneNumber = "+15430000567" },
        new Client { FullName = "Вазовский Майк Петрович", PhoneNumber = "+23334444555" },
        new Client { FullName = "Гудман Сол Александрович", PhoneNumber = "+77777777777" },
        new Client { FullName = "Чигур Антон Валерьевич", PhoneNumber = "+66666666666" },
        new Client { FullName = "Пинкман Джесси Евгеньевич", PhoneNumber = "+977712935030" },
        new Client { FullName = "Скалетта Вито Антонович", PhoneNumber = "+79004301983" },
    };

    /// <summary>Список заказов</summary>
    public static List<Order> Orders()
    {
        var clients = Clients();
        var items = Items();

        return new List<Order>
        {
            new Order { Client = clients[0], Item = items[0], AcceptanceDate = new(2025, 4, 10), CompletionDays = 5, Status = OrderStatus.Issued },
            new Order { Client = clients[1], Item = items[1], AcceptanceDate = new(2025, 5, 15), CompletionDays = 7, Status = OrderStatus.Issued },
            new Order { Client = clients[2], Item = items[2], AcceptanceDate = new(2025, 6, 20), CompletionDays = 3, Status = OrderStatus.Issued },
            new Order { Client = clients[0], Item = items[1], AcceptanceDate = new(2025, 7, 25), CompletionDays = 2, Status = OrderStatus.Issued },
            new Order { Client = clients[3], Item = items[3], AcceptanceDate = new(2025, 8, 30), CompletionDays = 4, Status = OrderStatus.Issued },
            new Order { Client = clients[4], Item = items[4], AcceptanceDate = new(2025, 10, 5), CompletionDays = 6, Status = OrderStatus.Issued },
            new Order { Client = clients[5], Item = items[5], AcceptanceDate = new(2025, 11, 10), CompletionDays = 10, Status = OrderStatus.Issued },
            new Order { Client = clients[0], Item = items[7], AcceptanceDate = new(2025, 12, 15), CompletionDays = 3, Status = OrderStatus.Issued },
            new Order { Client = clients[6], Item = items[8], AcceptanceDate = new(2026, 1, 20), CompletionDays = 5, Status = OrderStatus.Issued },
            new Order { Client = clients[7], Item = items[9], AcceptanceDate = new(2026, 2, 1), CompletionDays = 4, Status = OrderStatus.Issued },
            new Order { Client = clients[8], Item = items[0], AcceptanceDate = new(2026, 2, 10), CompletionDays = 2, Status = OrderStatus.Issued },
            new Order { Client = clients[1], Item = items[3], AcceptanceDate = new(2026, 2, 20), CompletionDays = 6, Status = OrderStatus.Ready },
            new Order { Client = clients[2], Item = items[2], AcceptanceDate = new(2026, 3, 1), CompletionDays = 5, Status = OrderStatus.InProgress },
            new Order { Client = clients[9], Item = items[5], AcceptanceDate = new(2026, 3, 5), CompletionDays = 2, Status = OrderStatus.InProgress },
            new Order { Client = clients[0], Item = items[6], AcceptanceDate = new(2026, 3, 10), CompletionDays = 3, Status = OrderStatus.InProgress },
            new Order { Client = clients[3], Item = items[2], AcceptanceDate = new(2024, 8, 10), CompletionDays = 5, Status = OrderStatus.Issued },
            new Order { Client = clients[4], Item = items[4], AcceptanceDate = new(2024, 11, 20), CompletionDays = 4, Status = OrderStatus.Issued },
        };
    }
}