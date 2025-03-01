namespace Shpr3;

class Program
{
    static void Main()
    {
        using (IDataSource dataProxy = new DataProxy())
        {
            Console.WriteLine(dataProxy.GetData("321"));
            Console.WriteLine(dataProxy.GetData("123"));
            Console.WriteLine(dataProxy.GetData("321"));
            Thread.Sleep(6000); // Ждем истечения срока кэша
            Console.WriteLine(dataProxy.GetData("123"));
            Console.WriteLine(dataProxy.GetData("321"));
        }
    }
}