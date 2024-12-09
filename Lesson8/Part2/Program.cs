namespace Part2;

public delegate void PongEventHandler(string message);
public delegate void PingEventHandler(string message);

public class Ping
{
    private Random rnd = new Random();

    // Событие, объявленное с использованием делегата
    public event PongEventHandler Ponged;

    public void SendPing()
    {
        int rndPing = rnd.Next(0, 10);
        Console.WriteLine("Ping отправляет Pong");
        if (rndPing != 3)
        {
            Ponged?.Invoke("Ping получил Pong");
        }
        else
        {
            Console.WriteLine("Ping промахнулся! Победил Pong");
        }
    }
}

public class Pong
{
    private Random rnd = new Random();

    // Событие, объявленное с использованием делегата
    public event PingEventHandler Pinged;

    public void SendPong()
    {
        int rndPong = rnd.Next(0, 10);
        Console.WriteLine("Pong отправляет Ping");
        if (rndPong != 3)
        {
            Pinged?.Invoke("Pong получил Ping");
        }
        else
        {
            Console.WriteLine("Pong промахнулся! Победил Ping");
        }
    }
}

class Program
{
    static void Main()
    {
        Ping ping = new Ping();
        Pong pong = new Pong();

        // Подписка на события
        ping.Ponged += (message) => { Console.WriteLine(message); pong.SendPong(); };
        pong.Pinged += (message) => { Console.WriteLine(message); ping.SendPing(); };

        ping.SendPing();
    }
}

