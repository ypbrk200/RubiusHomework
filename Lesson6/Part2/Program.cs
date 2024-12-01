namespace Part2;

class Program
{
    static void Main()
    {
        List<RegistrationRecord> records = new List<RegistrationRecord>();
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить запись");
            Console.WriteLine("2. Показать все записи (отсортировано по дате)");
            Console.WriteLine("3. Получить записи по дате");
            Console.WriteLine("4. Выход");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddRecord(records);
                    break;
                case "2":
                    ShowAllRecords(records);
                    break;
                case "3":
                    GetRecordsByDate(records);
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                    break;
            }
        }
    }

    // Метод добавления новой записи
    static void AddRecord(List<RegistrationRecord> records)
    {
        Console.Write("\nВведите фамилию: ");
        string surname = Console.ReadLine();

        Console.Write("Введите дату регистрации (гггг-мм-дд): ");
        string dateInput = Console.ReadLine();
        if (DateTime.TryParse(dateInput, out DateTime registrationDate))
        {
            records.Add(new RegistrationRecord(surname, registrationDate));
            Console.WriteLine("Запись успешно добавлена!");
        }
        else
        {
            Console.WriteLine("Некорректный формат даты. Пожалуйста, используйте формат гггг-мм-дд.");
        }
    }

    // Метод, показывающий все записи
    static void ShowAllRecords(List<RegistrationRecord> records)
    {
        var sortedRecords = records.OrderBy(r => r.RegistrationDate);

        Console.WriteLine("\nВсе записи (отсортированы по дате):");
        foreach (var record in sortedRecords)
        {
            Console.WriteLine($"{record.RegistrationDate:yyyy-MM-dd}: {record.Surname}");
        }
    }

    // Метод, показывающий записи за конкретную дату
    static void GetRecordsByDate(List<RegistrationRecord> records)
    {
        Console.Write("\nВведите дату для поиска (гггг-мм-дд): ");
        string dateInput = Console.ReadLine();
        if (DateTime.TryParse(dateInput, out DateTime searchDate))
        {
            var foundRecords = records.Where(r => r.RegistrationDate.Date == searchDate.Date).ToList();
            if (foundRecords.Any())
            {
                Console.WriteLine($"Записи за {searchDate:yyyy-MM-dd}:");
                foreach (var record in foundRecords)
                {
                    Console.WriteLine($"{record.RegistrationDate:yyyy-MM-dd}: {record.Surname}");
                }
            }
            else
            {
                Console.WriteLine("Записей за указанную дату не найдено.");
            }
        }
        else
        {
            Console.WriteLine("Некорректный формат даты. Пожалуйста, используйте формат гггг-мм-дд.");
        }
    }
}