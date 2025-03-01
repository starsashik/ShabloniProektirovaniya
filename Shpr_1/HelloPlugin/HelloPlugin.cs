using FactoryPlugin.FactoryApp;

public class HelloPlugin : IPlugin
{
    public void Initialize()
    {
        Console.WriteLine("HelloPlugin инициализирован");
    }

    public void Execute()
    {
        Console.WriteLine("HelloPlugin выполняет свою работу:\nВам привет!");
    }

    public void Terminate()
    {
        Console.WriteLine("HelloPlugin завершает свою работу");
    }
}