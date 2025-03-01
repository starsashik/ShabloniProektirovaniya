using FactoryPlugin.FactoryApp;

public class RandomNumberPlugin : IPlugin
{
    private Random? _random;

    public void Initialize()
    {
        _random = new Random();
        Console.WriteLine("RandomNumberPlugin инициализирован");
    }

    public void Execute()
    {
        Console.WriteLine($"RandomNumberPlugin выполняет свою работу:\nВаше число: {_random.Next(0, 100)}");
    }

    public void Terminate()
    {
        Console.WriteLine("RandomNumberPlugin завершает свою работу");
    }
}