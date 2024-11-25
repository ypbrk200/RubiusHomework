public class Trapezium : Shape, IPrintableShape
{
    private double baseA;
    private double baseB;
    private double sideC;
    private double sideD;
    private double height;
    public Trapezium(double baseA, double baseB, double sideC, double sideD)
    {
        if (TrySetBases(baseA, baseB, sideC, sideD))
        {
            CalculateHeight();
        }
        else
        {
            throw new ArgumentException("длины оснований и боковых сторон должны быть больше нуля.");
        }
    }
    private bool TrySetBases(double baseA, double baseB, double sideC, double sideD)
    {
        if (baseA < 0 || baseB < 0 || sideC < 0 || sideD < 0)
        {
            return false;
        }

        this.baseA = baseA;
        this.baseB = baseB;
        this.sideC = sideC;
        this.sideD = sideD;
        return true;
    }
    private void CalculateHeight()
    {
        double halfBaseDiff = Math.Abs(baseA - baseB) / 2;
        height = Math.Sqrt(sideC * sideC - halfBaseDiff * halfBaseDiff);
    }
    public override double CalculateArea() => (baseA + baseB) * height / 2;
    public override double CalculatePerimeter()
    {
        double sideLength = Math.Sqrt(height * height + Math.Pow((baseA - baseB) / 2, 2));
        return baseA + baseB + 2 * sideLength;
    }

    public void PrintType() => Console.WriteLine("Тип фигуры: Трапеция");
    public void PrintSquare() => Console.WriteLine($"Площадь: {CalculateArea()}");
    public void PrintPerimeter() => Console.WriteLine($"Периметр: {CalculatePerimeter()}");
}