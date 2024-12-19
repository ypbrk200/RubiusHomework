using System;
using System.Collections.Generic;
using Npgsql;

namespace Lesson10
{
    class Program
    {
        static string connectionString = "Host=localhost;Username=postgres;Password=1;Database=Lesson10";

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Выберите операцию: 1 - Чтение, 2 - Поиск, 3 - Добавление, 4 - Редактирование, 5 - Удаление, 0 - Выход");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ReadAll();
                        break;
                    case "2":
                        SearchById();
                        break;
                    case "3":
                        AddItem();
                        break;
                    case "4":
                        EditItem();
                        break;
                    case "5":
                        DeleteItem();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор!");
                        break;
                }
            }
        }

        static void ReadAll()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM Items", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("Список всех объектов:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader.GetInt32(0)}, Name: {reader.GetString(1)}, Description: {reader.GetString(2)}");
                    }
                }
            }
        }

        static void SearchById()
        {
            Console.Write("Введите Id объекта для поиска: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM Items WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"Id: {reader.GetInt32(0)}, Name: {reader.GetString(1)}, Description: {reader.GetString(2)}");
                        }
                        else
                        {
                            Console.WriteLine("Объект не найден.");
                        }
                    }
                }
            }
        }

        static void AddItem()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите описание: ");
            string description = Console.ReadLine();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO Items (Name, Description) VALUES (@name, @description)", conn))
                {
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("description", description);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Объект добавлен!");
        }

        static void EditItem()
        {
            Console.Write("Введите Id объекта для редактирования: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите новое имя объекта: ");
            string name = Console.ReadLine();

            Console.Write("Введите новое описание объекта: ");
            string description = Console.ReadLine();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("UPDATE Items SET Name = @name, Description = @description WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("description", description);
                    var affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        Console.WriteLine("Объект успешно обновлен!");
                    }
                    else
                    {
                        Console.WriteLine("Объект не найден или ничего не изменилось.");
                    }
                }
            }
        }


        static void DeleteItem()
        {
            Console.Write("Введите Id объекта для удаления: ");
            int id = Convert.ToInt32(Console.ReadLine());

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM Items WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    var affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        Console.WriteLine("Объект успешно удален!");
                    }
                    else
                    {
                        Console.WriteLine("Объект не найден.");
                    }
                }
            }
        }
    }
}