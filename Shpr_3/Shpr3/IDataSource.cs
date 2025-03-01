namespace Shpr3;

public interface IDataSource : IDisposable
{
    string GetData(string key);
}