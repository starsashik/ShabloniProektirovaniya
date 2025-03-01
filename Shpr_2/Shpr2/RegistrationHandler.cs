namespace Shpr2;

public class RegistrationHandler : Handler
{
    public override void HandleRequest(string username, string password, List<User> users, User? curUser)
    {
        if (users.Any(t => t.Username == username))
        {
            throw new Exception($"This username {username} is already existed");
        }

        Successor?.HandleRequest(username, password, users, curUser);
    }
}