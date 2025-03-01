using System.Reflection;

namespace FactoryPlugin.FactoryApp;

public static class PluginFactory
{
    public static List<IPlugin> Plugins = new List<IPlugin>();
    public static List<IPlugin> LoadPlugins(string pluginDirectory)
    {
        // Проверяем существует ли папка с плагинами
        if (!Directory.Exists(pluginDirectory))
        {
            Console.WriteLine($"Папка {pluginDirectory} не найдена.");
            return Plugins;
        }
        // Проверяем сколько плагинов есть в папке
        var files = Directory.GetFiles(pluginDirectory, "*.dll", SearchOption.AllDirectories);
        if (files.Length == 0)
        {
            Console.WriteLine($"В папке {pluginDirectory} нет плагинов. Файлы .dll отсутствуют.");
            return Plugins;
        }

        // Уведомление о том сколько найдено плагинов
        Console.WriteLine($"В папке {pluginDirectory} найдено {files.Length} плагинов.");

        // Загружаем все .dll файлы в указанной папке
        foreach (var file in files)
        {
            try
            {
                // Загружаем сборку (assembly)
                var assembly = Assembly.LoadFrom(file);

                // Ищем типы, которые реализуют интерфейс IPlugin
                var pluginTypes = assembly.GetTypes()
                    .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);

                // Создаем экземпляры плагинов
                foreach (var type in pluginTypes)
                {
                    if (Activator.CreateInstance(type) is IPlugin plugin)
                    {
                        Plugins.Add(plugin);
                        Console.WriteLine($"Загружен плагин: {plugin.GetType().Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке плагина из {file}: {ex.Message}");
            }
        }

        return Plugins;
    }
}
