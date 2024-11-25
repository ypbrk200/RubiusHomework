public class Rectangle : Shape, IPrintableShape
{
    private double width;
    private double height;
    public Rectangle(double width, double height)
    {
        if (!TrySetDimensions(width, height))
        {
            throw new ArgumentException("ширина и высота должны быть больше нуля .");
        }
    }
    public bool TrySetDimensions(double width, double height)
    {
        if (width > 0 && height > 0)
        {
            this.width = width;
            this.height = height;
            return true;
        }
        return false;
    }
    public override double CalculateArea() => width * height;
    public override double CalculatePerimeter() => 2 * (width + height);
    public void PrintType() => Console.WriteLine("Тип фигуры: Прямоугольник");
    public void PrintSquare() => Console.WriteLine($"Площадь: {CalculateArea()}");
    public void PrintPerimeter() => Console.WriteLine($"Периметр: {CalculatePerimeter()}");
}