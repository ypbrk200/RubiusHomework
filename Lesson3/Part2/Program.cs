namespace Part2;
// using System;
// using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> inventory = new Dictionary<string, int>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nМЕНЮ:");
            Console.WriteLine("1. Добавить товар");
            Console.WriteLine("2. Просмотреть все товары");
            Console.WriteLine("3. Удалить товар");
            Console.WriteLine("4. Найти товар");
            Console.WriteLine("5. Выйти");

            Console.Write("Введите номер действия: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct(inventory);
                    break;

                case "2":
                    ViewProducts(inventory);
                    break;

                case "3":
                    RemoveProduct(inventory);
                    break;

                case "4":
                    FindProduct(inventory);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                    break;
            }
        }
    }

    static void AddProduct(Dictionary<string, int> inventory)
    {
        Console.Write("\nВведите название товара: ");
        string productName = Console.ReadLine();

        Console.Write("Введите количество: ");
        int quantity;
        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
        {
            Console.WriteLine("Введите корректное количество (целое положительное число).");
        }

        if (inventory.ContainsKey(productName))
        {
            inventory[productName] += quantity;
            Console.WriteLine($"\nКоличество товара '{productName}' обновлено на {quantity}.");
        }
        else
        {
            inventory[productName] = quantity;
            Console.WriteLine($"\nТовар '{productName}' добавлен с количеством {quantity}.");
        }
    }

    static void ViewProducts(Dictionary<string, int> inventory)
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("\nСклад пуст.");
            return;
        }

        Console.WriteLine("\nТовары на складе:");
        foreach (var item in inventory)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    static void RemoveProduct(Dictionary<string, int> inventory)
    {
        Console.Write("\nВведите название товара для удаления: ");
        string productName = Console.ReadLine();

        if (inventory.ContainsKey(productName))
        {
            inventory.Remove(productName);
            Console.WriteLine($"Товар '{productName}' удален.");
        }
        else
        {
            Console.WriteLine($"Товар '{productName}' не найден.");
        }
    }

    static void FindProduct(Dictionary<string, int> inventory)
    {
        Console.Write("\nВведите название товара для поиска: ");
        string productName = Console.ReadLine();

        if (inventory.ContainsKey(productName))
        {
            Console.WriteLine($"Товар '{productName}': {inventory[productName]}.");
        }
        else
        {
            Console.WriteLine($"Товар '{productName}' не найден.");
        }
    }
}

