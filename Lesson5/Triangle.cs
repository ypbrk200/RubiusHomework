public class Triangle : Shape, IPrintableShape
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        if (!TrySetSides(sideA, sideB, sideC))
        {
            throw new ArgumentException("стороны должны быть больше нуля и соблюдаться неравенства треугольника.");
        }
    }

    public bool TrySetSides(double sideA, double sideB, double sideC)
    {
        if (sideA > 0 && sideB > 0 && sideC > 0 &&
            sideA + sideB > sideC &&
            sideA + sideC > sideB &&
            sideB + sideC > sideA)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
            return true;
        }
        return false;
    }

    public override double CalculateArea()
    {
        double s = CalculatePerimeter() / 2;
        return Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
    }

    public override double CalculatePerimeter() => sideA + sideB + sideC;

    public void PrintType() => Console.WriteLine("Тип фигуры: Треугольник");
    public void PrintSquare() => Console.WriteLine($"Площадь: {CalculateArea()}");
    public void PrintPerimeter() => Console.WriteLine($"Периметр: {CalculatePerimeter()}");
}