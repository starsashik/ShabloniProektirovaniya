namespace Shpr2;

public abstract class Handler
{
    public Handler? Successor { get; set; }
    public abstract void HandleRequest(string username, string password, List<User> users, User? curUser);
}