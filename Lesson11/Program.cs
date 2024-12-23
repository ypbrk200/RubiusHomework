using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Lesson11
{
    class Program
    {
        static void Main()
        {
            using (var context = new AppDbContext())
            {
                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("\nМеню действий:");
                    Console.WriteLine("1. Добавить автора");
                    Console.WriteLine("2. Просмотреть информацию об авторе");
                    Console.WriteLine("3. Обновить книгу");
                    Console.WriteLine("4. Удалить книгу");
                    Console.WriteLine("0. Выход");

                    Console.Write("\nВведите номер действия: ");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            AddAuthor(context);
                            break;
                        case "2":
                            ViewAuthorInfo(context);
                            break;
                        case "3":
                            UpdateBook(context);
                            break;
                        case "4":
                            DeleteBook(context);
                            break;
                        case "0":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                            break;
                    }
                }
            }
        }

        private static void AddAuthor(AppDbContext context)
        {
            Console.Write("Введите имя автора: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Имя автора не может быть пустым.");
                return;
            }

            Console.Write("Введите дату рождения автора (ДД.ММ.ГГГГ): ");
            string dateInput = Console.ReadLine();
            DateTime? dateOfBirth = null;

            if (!string.IsNullOrEmpty(dateInput))
            {
                if (!DateTime.TryParseExact(dateInput, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    Console.WriteLine("Неверный формат даты. Используйте ДД.ММ.ГГГГ.");
                    return;
                }
                dateOfBirth = parsedDate;
            }

            Console.Write("Введите краткую биографию автора: ");
            string biography = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(biography))
            {
                Console.WriteLine("Биография не может быть пустой.");
                return;
            }

            var author = new Author
            {
                Name = name,
                DateOfBirth = dateOfBirth,
                AuthorData = new AuthorData
                {
                    Biography = biography
                }
            };

            context.Authors.Add(author);
            context.SaveChanges();

            Console.WriteLine($"Автор '{name}' добавлен.");
        }

        private static void ViewAuthorInfo(AppDbContext context)
        {
            Console.Write("Введите имя автора для просмотра информации: ");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Имя автора не может быть пустым.");
                return;
            }

            var author = context.Authors
                .Include(a => a.AuthorData)
                .Include(a => a.Books)
                .FirstOrDefault(a => a.Name == name);

            if (author == null)
            {
                Console.WriteLine("Автор не найден.");
                return;
            }

            Console.WriteLine($"Информация об авторе:");
            Console.WriteLine($"- Имя: {author.Name}");
            Console.WriteLine($"- Дата рождения: {author.DateOfBirth?.ToString("dd.MM.yyyy") ?? "Неизвестна"}");
            Console.WriteLine($"- Биография: {author.AuthorData.Biography}");

            foreach (var book in author.Books)
            {
                Console.WriteLine($"- Книга: {book.Title}");
            }
        }

        private static void UpdateBook(AppDbContext context)
        {
            Console.Write("Введите название книги для обновления: ");
            string title = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Название книги не может быть пустым.");
                return;
            }

            var book = context.Books.FirstOrDefault(b => b.Title == title);

            if (book == null)
            {
                Console.WriteLine("Книга не найдена.");
                return;
            }

            Console.Write("Введите новое название книги: ");
            string newTitle = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newTitle))
            {
                Console.WriteLine("Новое название книги не может быть пустым.");
                return;
            }

            book.Title = newTitle;
            context.Update(book);
            context.SaveChanges();

            Console.WriteLine($"Книга '{title}' обновлена на '{newTitle}'.");
        }

        private static void DeleteBook(AppDbContext context)
        {
            Console.Write("Введите название книги для удаления: ");
            string title = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Название книги не может быть пустым.");
                return;
            }

            var book = context.Books.FirstOrDefault(b => b.Title == title);

            if (book == null)
            {
                Console.WriteLine("Книга не найдена.");
                return;
            }

            context.Remove(book);
            context.SaveChanges();

            Console.WriteLine($"Книга '{title}' удалена.");
        }
    }
}