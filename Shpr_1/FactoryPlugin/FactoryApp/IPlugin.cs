namespace FactoryPlugin.FactoryApp;

public interface IPlugin
{
    void Initialize(); // функция инициализации плагина
    void Execute(); // функция выполнения плагина
    void Terminate(); // функция завершения плагина
}
