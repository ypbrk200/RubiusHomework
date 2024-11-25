namespace Lesson5;

class Program
{
    static double inputDimension(string num)
    {
        double Dimension;
        if (!double.TryParse(num, out Dimension))
        {
            Console.WriteLine("Введите число: ");
            while (!double.TryParse(Console.ReadLine(), out Dimension))
            {
                Console.Write("Введите число: ");
            }
            return Dimension;
        }
        else
        {
            return Dimension;
        }
    }
    static void Main()
    {
        // Примеры использования (задание 2)
        Console.Write("Круг. Введите длину радиуса: ");
        double Radius = inputDimension(Console.ReadLine());
        try
        {
            Circle circle = new Circle(Radius);
            circle.PrintType();
            circle.PrintSquare();
            circle.PrintPerimeter();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Фигура 'Круг' - ошибка: {ex.Message}");
        }
        Console.Write("Прямоугольник. Введите длину: ");
        double rectA = inputDimension(Console.ReadLine());
        Console.Write("Прямоугольник. Введите ширину: ");
        double rectB = inputDimension(Console.ReadLine());
        try
        {
            Rectangle rectangle = new Rectangle(rectA, rectB);
            rectangle.PrintType();
            rectangle.PrintSquare();
            rectangle.PrintPerimeter();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Фигура 'Прямоугольник' - ошибка: {ex.Message}");
        }
        Console.Write("Треугольник. Введите длину стороны 1: ");
        double triA = inputDimension(Console.ReadLine());
        Console.Write("Треугольник. Введите длину стороны 2: ");
        double triB = inputDimension(Console.ReadLine());        
        Console.Write("Треугольник. Введите длину стороны 3: ");
        double triC = inputDimension(Console.ReadLine());
        try
        {
            Triangle triangle = new Triangle(triA, triB, triC);
            triangle.PrintType();
            triangle.PrintSquare();
            triangle.PrintPerimeter();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Фигура 'Треугольник' - ошибка: {ex.Message}");
        }        
        Console.Write("Трапеция. Введите длину верхнего основания: ");
        double trapA = inputDimension(Console.ReadLine());
        Console.Write("Трапеция. Введите длину нижнего основания: ");
        double trapB = inputDimension(Console.ReadLine());        
        Console.Write("Трапеция. Введите длину левой стороны: ");
        double trapC = inputDimension(Console.ReadLine());        
        Console.Write("Трапеция. Введите длину правой стороны: ");
        double trapD = inputDimension(Console.ReadLine());
        try
        {
            Trapezium trapezium = new Trapezium(trapA, trapB, trapC, trapD);
            trapezium.PrintType();
            trapezium.PrintSquare();
            trapezium.PrintPerimeter();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Фигура 'Трапеция' - ошибка: {ex.Message}");
        }
        Console.Write("Нажмите любую кнопку, чтобы закрыть...");
        Console.ReadKey();
    }
}
