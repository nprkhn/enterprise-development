using DryCleaner.Domain.Entities;
using DryCleaner.Shared.Enums;

namespace DryCleaner.Domain.Data;

/// <summary>
/// Тестовые данные химчистки
/// </summary>
public static class DataSeed
{
    /// <summary>
    /// Категории изделий
    /// </summary>
    public static List<ItemCategory> Categories { get; } = new()
    {
        new ItemCategory { Id = 0, Name = "Верхняя одежда", RecommendedCleaning = CleaningType.DryCleaning, Price = 1500 },
        new ItemCategory { Id = 1, Name = "Пальто", RecommendedCleaning = CleaningType.DryCleaning, Price = 2000 },
        new ItemCategory { Id = 2, Name = "Платье", RecommendedCleaning = CleaningType.DryCleaning, Price = 1200 },
        new ItemCategory { Id = 3, Name = "Костюм", RecommendedCleaning = CleaningType.DryCleaning, Price = 1800 },
        new ItemCategory { Id = 4, Name = "Рубашка", RecommendedCleaning = CleaningType.Ironing, Price = 500  },
        new ItemCategory { Id = 5, Name = "Брюки", RecommendedCleaning = CleaningType.Ironing, Price = 800  },
        new ItemCategory { Id = 6, Name = "Постельное бельё", RecommendedCleaning = CleaningType.AquaCleaning, Price = 700  },
        new ItemCategory { Id = 7, Name = "Спортивная одежда", RecommendedCleaning = CleaningType.WetCleaning, Price = 600  },
        new ItemCategory { Id = 8, Name = "Куртка", RecommendedCleaning = CleaningType.DryCleaning, Price = 1700 },
        new ItemCategory { Id = 9, Name = "Шуба", RecommendedCleaning = CleaningType.DryCleaning, Price = 5000 },
    };

    /// <summary>
    /// Список изделий
    /// </summary>
    public static List<Item> Items { get; } = new()
    {
        new Item { Id = 0, Name = "Пальто", Category = Categories[1], CategoryId = 1, Material = "Шерсть" },
        new Item { Id = 1,Name = "Пиджак", Category = Categories[3], CategoryId = 3, Material = "Хлопок" },
        new Item { Id = 2, Name = "Платье свадебное", Category = Categories[2], CategoryId = 2, Material = "Шёлк" },
        new Item { Id = 3, Name = "Рубашка в клеточку", Category = Categories[4], CategoryId = 4, Material = "Хлопок" },
        new Item { Id = 4, Name = "Брюки замшевые", Category = Categories[5], CategoryId = 5, Material = "Шерсть" },
        new Item { Id = 5, Name = "Куртка", Category = Categories[8], CategoryId = 8, Material = "Кожа" },
        new Item { Id = 6, Name = "Шуба норковая", Category = Categories[9], CategoryId = 9, Material = "Мех" },
        new Item { Id = 7, Name = "Костюм тройка", Category = Categories[3], CategoryId = 3, Material = "Шерсть" },
        new Item { Id = 8, Name = "Футбольная форма", Category = Categories[7], CategoryId = 7, Material = "Синтетика" },
        new Item { Id = 9, Name = "Постельное бельё", Category = Categories[6], CategoryId = 6, Material = "Хлопок" },
    };

    /// <summary>
    /// Список клиентов
    /// </summary>
    public static List<Costumer> Costumers = new()
    {
        new Costumer { Id = 0, LastName = "Евлампьев", FirstName = "Евлампий", MiddleName = "Евлампиевич", PhoneNumber = "+79001112233" },
        new Costumer { Id = 1, LastName = "Сергеев", FirstName = "Александр", MiddleName = "Сильвестрович", PhoneNumber = "+79000000000" },
        new Costumer { Id = 2, LastName = "Сергеев", FirstName = "Александр", MiddleName = "Александрович", PhoneNumber = "+79000000001" },
        new Costumer { Id = 3, LastName = "Баринов", FirstName = "Виктор", MiddleName = "Петрович", PhoneNumber = "+78005553535" },
        new Costumer { Id = 4, LastName = "Уайт", FirstName = "Уолтер", MiddleName = "Хартвелл", PhoneNumber = "+15430000567" },
        new Costumer { Id = 5, LastName = "Вазовский", FirstName = "Майк", MiddleName = "Петрович", PhoneNumber = "+23334444555" },
        new Costumer { Id = 6, LastName = "Гудман", FirstName = "Сол", MiddleName = "Александрович", PhoneNumber = "+77777777777" },
        new Costumer { Id = 7, LastName = "Чигур", FirstName = "Антон", MiddleName = "Валерьевич", PhoneNumber = "+66666666666" },
        new Costumer { Id = 8, LastName = "Пинкман", FirstName = "Джесси", MiddleName = "Евгеньевич", PhoneNumber = "+977712935030" },
        new Costumer { Id = 9, LastName = "Скалетта", FirstName = "Вито", MiddleName = "Антонович", PhoneNumber = "+79004301983" },
    };

    /// <summary>
    /// Список заказов
    /// </summary>
    public static List<Order> Orders { get; } = new()
    {
        new Order { Id = 0, Costumer = Costumers[0], CostumerId = 0, Item = Items[0], ItemId = 0, AcceptanceDate = new(2025, 4, 10), CompletionDays = 5, Status = OrderStatus.Issued },
        new Order { Id = 1, Costumer = Costumers[1], CostumerId = 1, Item = Items[1], ItemId = 1, AcceptanceDate = new(2025, 5, 15), CompletionDays = 7, Status = OrderStatus.Issued },
        new Order { Id = 2, Costumer = Costumers[2], CostumerId = 2, Item = Items[2], ItemId = 2, AcceptanceDate = new(2025, 6, 20), CompletionDays = 3, Status = OrderStatus.Issued },
        new Order { Id = 3, Costumer = Costumers[0], CostumerId = 0, Item = Items[1], ItemId = 1, AcceptanceDate = new(2025, 7, 25), CompletionDays = 2, Status = OrderStatus.Issued },
        new Order { Id = 4, Costumer = Costumers[3], CostumerId = 3, Item = Items[3], ItemId = 3, AcceptanceDate = new(2025, 8, 30), CompletionDays = 4, Status = OrderStatus.Issued },
        new Order { Id = 5, Costumer = Costumers[4], CostumerId = 4, Item = Items[4], ItemId = 4, AcceptanceDate = new(2025, 10, 5), CompletionDays = 6, Status = OrderStatus.Issued },
        new Order { Id = 6, Costumer = Costumers[5], CostumerId = 5, Item = Items[5], ItemId = 5, AcceptanceDate = new(2025, 11, 10), CompletionDays = 10, Status = OrderStatus.Issued },
        new Order { Id = 7, Costumer = Costumers[0], CostumerId = 0, Item = Items[7], ItemId = 7, AcceptanceDate = new(2025, 12, 15), CompletionDays = 3, Status = OrderStatus.Issued },
        new Order { Id = 8, Costumer = Costumers[6], CostumerId = 6, Item = Items[8], ItemId = 8, AcceptanceDate = new(2026, 1, 20), CompletionDays = 5, Status = OrderStatus.Issued },
        new Order { Id = 9, Costumer = Costumers[7], CostumerId = 7, Item = Items[9], ItemId = 9, AcceptanceDate = new(2026, 2, 1), CompletionDays = 4, Status = OrderStatus.Issued },
        new Order { Id = 10, Costumer = Costumers[8], CostumerId = 8, Item = Items[0], ItemId = 0, AcceptanceDate = new(2026, 2, 10), CompletionDays = 2, Status = OrderStatus.Issued },
        new Order { Id = 11, Costumer = Costumers[1], CostumerId = 1, Item = Items[3], ItemId = 3, AcceptanceDate = new(2026, 2, 20), CompletionDays = 6, Status = OrderStatus.Ready },
        new Order { Id = 12, Costumer = Costumers[2], CostumerId = 2, Item = Items[2], ItemId = 2, AcceptanceDate = new(2026, 3, 1), CompletionDays = 5, Status = OrderStatus.InProgress },
        new Order { Id = 13, Costumer = Costumers[9], CostumerId = 9, Item = Items[5], ItemId = 5, AcceptanceDate = new(2026, 3, 5), CompletionDays = 2, Status = OrderStatus.InProgress },
        new Order { Id = 14, Costumer = Costumers[0], CostumerId = 0, Item = Items[6], ItemId = 6, AcceptanceDate = new(2026, 3, 10), CompletionDays = 3, Status = OrderStatus.InProgress },
        new Order { Id = 15, Costumer = Costumers[3], CostumerId = 3, Item = Items[2], ItemId = 2, AcceptanceDate = new(2024, 8, 10), CompletionDays = 5, Status = OrderStatus.Issued },
        new Order { Id = 16, Costumer = Costumers[4], CostumerId = 4, Item = Items[4], ItemId = 4, AcceptanceDate = new(2024, 11, 20), CompletionDays = 4, Status = OrderStatus.Issued },
    };
}