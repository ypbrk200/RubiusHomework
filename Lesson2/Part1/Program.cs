namespace Lesson2;

class Program
{
    static void Main(string[] args)
    {
        int year;
        Console.Write("Введите год: ");
        while (!int.TryParse(Console.ReadLine(), out year) || year <= 0 || year >= 30000)
        {
            Console.Write("Год должен быть целым числом в диапазоне от 0 до 30000: ");
        }
        if(year % 4 == 0 && year % 100 != 0)
        {
            Console.WriteLine("YES");
        }
        else if(year % 400 == 0)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }       
    }
}
