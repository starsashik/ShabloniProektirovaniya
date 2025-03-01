namespace FactoryPlugin.FactoryApp;

class Program
{
    static void Main()
    {
        Console.WriteLine("Начинается загрузка плагинов...");
        // ссылка на папку, в которой находятся плагины
        string pluginDirectory = @"C:\Users\alexa\RiderProjects\ShabloniProektirovaniya\Shpr_1\FactoryPlugin\Plugins";
        // Загружаем плагины через фабрику
        var plugins = PluginFactory.LoadPlugins(pluginDirectory);

        if (plugins.Count == 0)
        {
            Console.WriteLine("Найдено 0 плагинов для загрузки - завершаю работу программы.");
            return;
        }

        // Переменная текущего плагина, который выберет пользователь
        IPlugin? currentPlugin = null;
        // Цикл для выбора плагина
         while (true)
        {
            Console.WriteLine("Загруженные плагины");
            for (int i = 0; i < plugins.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {plugins[i].GetType().Name}");
            }

            // Чтение выбора пользователя
            Console.Write("Введите номер плагина: ");
            if (!int.TryParse(Console.ReadLine(), out int pluginIndex) || pluginIndex < 1 || pluginIndex > plugins.Count)
            {
                Console.WriteLine($"Вы ввели неправильный номер. Допустимый номер {1} - {plugins.Count}");
                continue; // Повторяем наш цикл для выбора плагина
            }

            // Выбираем плагин из списка по номеру
            currentPlugin = plugins[pluginIndex - 1];

            // Цикл для работы с текущим плагином
            while (true)
            {
                Console.WriteLine($"\nВыбранный плагин {currentPlugin.GetType().Name}. Что вы хотите сделать:\n" +
                                  "1 - Инициализировать плагин\n" +
                                  "2 - Выполнить плагин\n" +
                                  "3 - Завершить работу плагина\n" +
                                  "4 - Вернуться к выбору плагина \n" +
                                  "5 - Завершить работу программы"
                                  );
                // Чтение выбора пользователя
                Console.Write("Введите номер действия: ");
                if (!int.TryParse(Console.ReadLine(), out int idAction) || pluginIndex < 1 || pluginIndex > 5)
                {
                    Console.WriteLine("Вы ввели неправильный номер. Допустимый номер 1 - 5");
                    continue; // Повторяем цикл для работы с плагином
                }

                switch (idAction)
                {
                    case 1:
                        currentPlugin.Initialize();
                        break;
                    case 2:
                        currentPlugin.Execute();
                        break;
                    case 3:
                        currentPlugin.Terminate();
                        break;
                    case 4:
                        break;
                    case 5:
                        Console.WriteLine("Завершаю работу программы");
                        return;
                }

                // Мы должны вернуться в цикл выбора плагина
                if (idAction == 4)
                {
                    break;
                }
            }
        }
    }
}
