namespace Shpr2;

public class ExistenceHandler : Handler
{
    public override void HandleRequest(string username, string password, List<User> users, User? curUser)
    {
        if (curUser != null)
        {
            throw new Exception("First, you need to log out of your current account.");
        }

        Successor?.HandleRequest(username, password, users, curUser);
    }
}