namespace Lesson5;

class Program
{
    static void Main()
    {
        // Примеры использования (задание 2)
        try
        {
            Circle circle = new Circle(-5);
            circle.PrintType();
            circle.PrintSquare();
            circle.PrintPerimeter();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Фигура 'Круг' - ошибка: {ex.Message}");
        }
        try
        {
            Rectangle rectangle = new Rectangle(-4, 6);
            rectangle.PrintType();
            rectangle.PrintSquare();
            rectangle.PrintPerimeter();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Фигура 'Прямоугольник' - ошибка: {ex.Message}");
        }
        try
        {

            Triangle triangle = new Triangle(3, 0, 5);
            triangle.PrintType();
            triangle.PrintSquare();
            triangle.PrintPerimeter();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Фигура 'Треугольник' - ошибка: {ex.Message}");
        }
        try
        {
            Trapezium trapezium = new Trapezium(5, -7, 4, 3);
            trapezium.PrintType();
            trapezium.PrintSquare();
            trapezium.PrintPerimeter();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Фигура 'Трапеция' - ошибка: {ex.Message}");
        }
    }
}
