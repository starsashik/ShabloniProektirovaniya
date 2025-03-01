namespace Shpr3;

public class TextFileReader : IDataSource
{
    private TimeSpan CacheDuration {get; set;}
    public TextFileReader(TimeSpan cacheDuration)
    {
        CacheDuration = cacheDuration;
    }

    // Поиск данных по ключу без мгновенного кеширования
    public string GetData(string key)
    {
        Console.WriteLine("Открыт файл"); // Сообщение для отслеживания открытия файла
        var streamReader = new StreamReader(@"C:\Users\alexa\RiderProjects\ShabloniProektirovaniya\Shpr_3\Shpr3\Data.txt");
        var line = streamReader.ReadLine();
        while (line is not null) // Перебор всех строк
        {
            if (line.Split(':')[0] == key)
            {
                return line.Split(':')[1]; // Возвращение нужного значения
            }

            line = streamReader.ReadLine();
        }
        streamReader.Close();
        throw new Exception($"No data was found for this key {key}."); // Ошибка если строка не найдена
    }

    // Поиск данных по ключу с мгновенным кешированием
    public string GetDataWithCache(string key, Dictionary<string, (string Data, DateTime Expiration)> cache)
    {
        Console.WriteLine("Открыт файл"); // Сообщение для отслеживания открытия файла
        var streamReader = new StreamReader(@"C:\Users\alexa\RiderProjects\ShabloniProektirovaniya\Shpr_3\Shpr3\Data.txt");
        var line = streamReader.ReadLine();
        while (line is not null) // Перебор всех строк
        {
            // Если в словаре еще нет записи для считанной строки, то для нее создается запись
            if (!cache.ContainsKey(line.Split(':')[0]))
            {
                cache.Add(line.Split(':')[0], (line.Split(':')[1], DateTime.Now + CacheDuration));
            }

            // Если запись просрочена, мы ее обновляем по ключам
            if (cache.TryGetValue(line.Split(':')[0], out var cachedEntry) && cachedEntry.Expiration > DateTime.Now)
            {
                cache[line.Split(':')[0]] = (line.Split(':')[1], DateTime.Now + CacheDuration);
            }

            if (line.Split(':')[0] == key)
            {
                return line.Split(':')[1]; // Возвращение нужного значения
            }

            line = streamReader.ReadLine();
        }
        streamReader.Close();
        throw new Exception($"No data was found for this key {key}."); // Ошибка если строка не найдена
    }

    public void Dispose()
    {
        Console.WriteLine("TextFileReader: освобождение ресурсов");
    }
}