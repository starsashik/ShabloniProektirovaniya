namespace Shpr3;


public class DataProxy : IDataSource
{
    private TextFileReader? TextFileReader { get; set; }
    private Dictionary<string, (string Data, DateTime Expiration)> Cache { get; set; }
    private readonly TimeSpan _cacheDuration = TimeSpan.FromSeconds(5);

    public DataProxy()
    {
        Cache = new Dictionary<string, (string Data, DateTime Expiration)>();
    }

    public string GetData(string key)
    {
        // Считываем данные из кеша, если они есть. Проверяем что время их существования не истекло (данные остались актуальны)
        if (Cache.TryGetValue(key, out var cachedEntry) && cachedEntry.Expiration > DateTime.Now)
        {
            Console.WriteLine($"[КЭШ] Данные получены из кэша: {key}");
            return cachedEntry.Data;
        }

        // Если данных не нашлось, то следует обращение к файлу
        TextFileReader ??= new TextFileReader(_cacheDuration);

        // Чтение из файла без мгновенного кеширования и кеширование только результата
        // string data = TextFileReader.GetData(key);
        // Cache[key] = (data, DateTime.Now + _cacheDuration);
        // Console.WriteLine($"[ИСТОЧНИК] Получены новые данные: {key}");
        // return data;

        // Чтение из файла с мгновенным кешированием и обновляем просроченных данных
        string data = TextFileReader.GetDataWithCache(key, Cache);
        Console.WriteLine($"[ИСТОЧНИК] Получены новые данные: {key}");
        return data;
    }

    public void Dispose()
    {
        TextFileReader?.Dispose();
    }
}