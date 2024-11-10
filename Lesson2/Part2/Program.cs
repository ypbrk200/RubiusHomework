namespace Lesson2;

class Program
{
    static void Main
    {        
        int amount;
        decimal total = 0;
        decimal expense;
        Console.Write("Введите количество расходов: ");
        while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.Write("Количество расходов должно быть целым положительным числом: ");
        }
        for (int i = 1; i <= amount; i++)
        {
            Console.Write($"Введите сумму расхода {i}: ");
            while (!decimal.TryParse(Console.ReadLine(), out expense) || expense < 0)
            {
                Console.Write("Сумма расхода должна быть положительным числом: ");
            }
            total += expense;
        }
        Console.WriteLine($"Общие расходы за месяц составляют: {total}. Очень много :(");
    }
}
