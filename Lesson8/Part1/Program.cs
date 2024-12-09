namespace Part1;

using System;

public delegate void NumberReachedEventHandler(int number);

public class Counter
{
    // Событие, объявленное с использованием делегата
    public event NumberReachedEventHandler NumberReached;

    public void StartCounting()
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine(i);
            if (i == 77)
            {
                // Вызываем событие
                NumberReached?.Invoke(i);
            }
        }
    }
}

public class Handler1
{
    public void OnNumberReached(int number)
    {
        Console.WriteLine("Пора действовать, ведь уже 77");
    }
}

public class Handler2
{
    public void OnNumberReached(int number)
    {
        Console.WriteLine("Уже 77, давно пора было начать!");
    }
}

class Program
{
    static void Main()
    {
        Random rnd = new Random();
        int rndHandler = rnd.Next(0, 10);
        Counter counter = new Counter();
        Handler1 handler1 = new Handler1();
        Handler2 handler2 = new Handler2();

        // Подписка на событие
        if (rndHandler < 5)
        {
            counter.NumberReached += handler1.OnNumberReached;
        }
        else if (rndHandler > 4)
        {
            counter.NumberReached += handler2.OnNumberReached;
        }

        counter.StartCounting();
    }
}

