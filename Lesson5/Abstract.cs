// В этом файле выполнено задание 1: спроектирован абстрактный класс и определен интерфейс
// Классы-наследники созданы в файлах Circle, Rectangle, Triangle, Trapecium
// В классах-наследниках выполнено задание 2.
public interface IPrintableShape
{
    void PrintType();
    void PrintSquare();
    void PrintPerimeter();
}
public abstract class Shape
{
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
}