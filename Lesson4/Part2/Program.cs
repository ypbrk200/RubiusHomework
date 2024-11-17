public class Program
{
    public static void Main()
    {
        string[] transportTypes = { "Водный", "Воздушный", "Наземный" };

        string[,] subtypes =
        {
            {"Катер", "Подводная лодка", "Яхта"},
            {"Вертолет", "Самолет", "Дирижабль"},
            {"Автомобиль", "Мотоцикл", "Поезд"}
        };

        Console.WriteLine("Выберите тип транспорта:");        
        for (int i = 0; i < transportTypes.Length; i++)
        {
            Console.WriteLine($"{i + 1}) {transportTypes[i]}");
        }

        int typeIndex = GetUserInput(transportTypes.Length);
        string selectedType = transportTypes[typeIndex - 1];

        Console.WriteLine($"\nВы выбрали: {selectedType} транспорт.");

        Console.WriteLine("\nДоступные подтипы выбранного транспорта:");
        for (int j = 0; j < subtypes.GetLength(1); j++)
        {
            Console.WriteLine($"{j + 1}) {subtypes[typeIndex - 1, j]}");
        }

        int subtypeIndex = GetUserInput(subtypes.GetLength(1));
        string selectedSubtype = subtypes[typeIndex - 1, subtypeIndex - 1];

        Console.WriteLine($"\nОтличный выбор! Вы передвигаетесь на: {selectedSubtype}, тип транспорта: {selectedType}.");
    }

    static int GetUserInput(int maxValue)
    {
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                Console.WriteLine($"Пожалуйста, введите число от 1 до {maxValue}");
                continue;
            }

            if (input >= 1 && input <= maxValue)
            {
                return input;
            }
            else
            {
                Console.WriteLine($"Пожалуйста, введите число от 1 до {maxValue}");
            }
        }
    }
}