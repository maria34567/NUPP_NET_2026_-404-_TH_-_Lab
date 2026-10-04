using System;
using Store.Common;

namespace Store.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ЛАБОРАТОРНА РОБОТА №1 ===\n");

            // Ініціалізація сервісу
            var productService = new InMemoryCrudService<Product>();

            // Підписка на подію (Делегати та Події)
            productService.OnItemAdded += item => 
            {
                Console.WriteLine($"[ПОДІЯ] Додано новий товар: {item.Name}");
            };

            // 1. Створення об'єктів
            var laptop = new Electronics("Ноутбук", 35000m, "ASUS", 24);
            var phone = new Electronics("Смартфон", 20000m, "Samsung", 12);

            // 2. Додавання в CRUD (Create)
            Console.WriteLine("--- Додавання елементів ---");
            productService.Create(laptop);
            productService.Create(phone);

            // Статичний метод
            Console.WriteLine();
            Product.DisplayTotalCount();

            // 3. Вивід усіх елементів (ReadAll)
            Console.WriteLine("\n--- Список усіх товарів у CRUD ---");
            foreach (var item in productService.ReadAll())
            {
                Console.WriteLine(item.GetInfo());
            }

            // 4. Пошук (Read)
            Console.WriteLine("\n--- Пошук за ID ---");
            var found = productService.Read(phone.Id);
            Console.WriteLine($"Знайдено: {found.GetInfo()}");

            // 5. Видалення (Remove)
            Console.WriteLine("\n--- Видалення товару ---");
            productService.Remove(phone);

            Console.WriteLine("\n--- Список товарів після видалення ---");
            foreach (var item in productService.ReadAll())
            {
                Console.WriteLine(item.GetInfo());
            }

            // 6. Додаткове завдання (Збереження та завантаження JSON)
            string filePath = "products.json";
            Console.WriteLine($"\n--- Збереження списку у файл {filePath} ---");
            productService.Save(filePath);
            Console.WriteLine("Дані успішно збережено.");

            Console.WriteLine("\n--- Завантаження з файлу у новий сервіс ---");
            var newService = new InMemoryCrudService<Product>();
            newService.Load(filePath);

            foreach (var item in newService.ReadAll())
            {
                Console.WriteLine($"[З файлу]: {item.GetInfo()}");
            }

            Console.WriteLine("\nРоботу виконано успішно!");
        }
    }
}