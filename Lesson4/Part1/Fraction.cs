public class Fraction
{
    private int numerator;
    private int denominator;

    // Конструктор
    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
        Simplify();
    }

    // Геттеры и сеттеры
    public int Numerator
    {
        get { return numerator; }
        set
        {
            numerator = value;
            Simplify();
        }
    }

    public int Denominator
    {
        get { return denominator; }
        set
        {
            denominator = value;
            Simplify();
        }
    }

    // Метод вывода на экран
    public void Print()
    {
        Console.WriteLine($"{numerator}/{denominator}");
    }

    // Простейшие математические операции
    public static Fraction operator +(Fraction a, Fraction b)
    {
        int newNumerator = a.numerator * b.denominator + b.numerator * a.denominator;
        int newDenominator = a.denominator * b.denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        int newNumerator = a.numerator * b.denominator - b.numerator * a.denominator;
        int newDenominator = a.denominator * b.denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        int newNumerator = a.numerator * b.numerator;
        int newDenominator = a.denominator * b.denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        int newNumerator = a.numerator * b.denominator;
        int newDenominator = a.denominator * b.numerator;
        return new Fraction(newNumerator, newDenominator);
    }

    public float ToFloat()
    {
        return (float)numerator / denominator;
    }

    public double ToDouble()
    {
        return (double)numerator / denominator;
    }

    // Упрощение дроби
    private void Simplify()
    {
        int gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;

        // Убедимся, что знаменатель положительный
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }
    }

    // Нахождение НОД
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return Math.Abs(a);
    }
}