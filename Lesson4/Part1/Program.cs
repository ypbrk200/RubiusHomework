public class Program
{
    // Метод, для ввода числителя с клавиатуры
    static int inputNumer(string num)
    {
        int fractionPart;
        if (!int.TryParse(num, out fractionPart))
        {
            Console.WriteLine("Числитель должен быть целым: ");
            while (!int.TryParse(Console.ReadLine(), out fractionPart))
            {
                Console.Write("Числитель должен быть целым: ");
            }
            return fractionPart;
        }
        else
        {
            return fractionPart;
        }
    }

    // Метод, для ввода знаменателя с клавиатуры
    static int inputDenomer(string num)
    {
        int fractionPart;
        if (!int.TryParse(num, out fractionPart) || fractionPart == 0)
        {
            Console.WriteLine("Знаменатель должен быть целым и не равным 0: ");
            while (!int.TryParse(Console.ReadLine(), out fractionPart) || fractionPart == 0)
            {
                Console.Write("Знаменатель должен быть целым и не равным 0: ");
            }
            return fractionPart;
        }
        else
        {
            return fractionPart;
        }
    }
    public static void Main()
    {
        Console.WriteLine("Введите числитель первой дроби:");
        int numer1 = inputNumer(Console.ReadLine());

        Console.WriteLine("Введите знаменатель первой дроби:");
        int denom1 = inputDenomer(Console.ReadLine());

        Console.WriteLine("Введите числитель второй дроби:");
        int numer2 = inputNumer(Console.ReadLine());
        
        Console.WriteLine("Введите знаменатель второй дроби:");
        int denom2 = inputDenomer(Console.ReadLine());

        Fraction fraction1 = new Fraction(numer1, denom1);
        Fraction fraction2 = new Fraction(numer2, denom2);

        Fraction sum = fraction1 + fraction2;
        Fraction difference = fraction1 - fraction2;
        Fraction product = fraction1 * fraction2;
        Fraction quotient = fraction1 / fraction2;

        Console.Write("Сумма: ");
        sum.Print();
        Console.Write("Разность: ");
        difference.Print();
        Console.Write("Умножение: ");
        product.Print();
        Console.Write("Деление: ");
        quotient.Print();

        Console.WriteLine($"Дробь 1 в формате float: {fraction1.ToFloat()}");
        Console.WriteLine($"Дробь 1 в формате double: {fraction1.ToDouble()}");
        Console.WriteLine($"Дробь 2 в формате float: {fraction2.ToFloat()}");
        Console.WriteLine($"Дробь 2 в формате double: {fraction2.ToDouble()}");
    }
}