public class Circle : Shape, IPrintableShape
{
    private double radius;
    public Circle(double radius)
    {
        if (!TrySetRadius(radius))
        {
            throw new ArgumentException("радиус должен быть больше нуля.");
        }
    }
    public bool TrySetRadius(double radius)
    {
        if (radius > 0)
        {
            this.radius = radius;
            return true;
        }
        return false;
    }
    public override double CalculateArea() => Math.PI * radius * radius;
    public override double CalculatePerimeter() => 2 * Math.PI * radius;
    public void PrintType() => Console.WriteLine("Тип фигуры: Круг");
    public void PrintSquare() => Console.WriteLine($"Площадь: {CalculateArea()}");
    public void PrintPerimeter() => Console.WriteLine($"Периметр: {CalculatePerimeter()}");
}