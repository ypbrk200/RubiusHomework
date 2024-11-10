namespace Lesson3;

class Program
{
    static decimal CalcTax(decimal income)
    {
        decimal taxRate = 0.13m; // Налоговая ставка 13%
        decimal tax = income * taxRate;

        // Округление до 2 знаков после запятой
        return Math.Round(tax, 2);
    }

    static void Main()
    {
        decimal income;
        Console.Write("Введите сумму дохода: ");
        while (!decimal.TryParse(Console.ReadLine(), out income) || income < 0) // Проверка ввода
        {
            Console.Write("Количество расходов должно быть положительным числом: ");
        }
        decimal tax = CalcTax(income);
        Console.WriteLine($"Сумма налогов к уплате: {tax} рублей.");
    }

}
