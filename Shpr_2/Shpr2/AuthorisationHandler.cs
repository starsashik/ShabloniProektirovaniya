namespace Shpr2;

public class AuthorisationHandler : Handler
{
    public override void HandleRequest(string username, string password, List<User> users, User? curUser)
    {
        if (users.Any(t => t.Username == username && t.Password == password))
        {
            Successor?.HandleRequest(username, password, users, curUser);
            return;
        }
        throw new Exception("Invalid username or password");
    }
}