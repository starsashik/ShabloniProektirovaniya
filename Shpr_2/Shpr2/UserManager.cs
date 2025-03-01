namespace Shpr2;

public class UserManager
{
    private List<User> Users { get; set; } = new();
    public User? CurrentUser { get; set; } = null;

    public void Registration(string username, string password)
    {
        try
        {
            var h1 = new ExistenceHandler();
            var h2 = new CorrectnessHandler();
            var h3 = new RegistrationHandler();
            h1.Successor = h2;
            h2.Successor = h3;

            h1.HandleRequest(username, password, Users, CurrentUser);
            var user = new User(username, password);
            Users.Add(user);
            CurrentUser = user;
            Console.WriteLine($"New user \"{username}\" has been successfully registered and logged into his account");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Authorisation(string username, string password)
    {
        try
        {
            var h1 = new ExistenceHandler();
            var h2 = new CorrectnessHandler();
            var h3 = new AuthorisationHandler();
            h1.Successor = h2;
            h2.Successor = h3;

            h1.HandleRequest(username, password, Users, CurrentUser);
            CurrentUser = new User(username, password);
            Console.WriteLine($"User \"{username}\" successfully logged into his account");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void Logout()
    {
        try
        {
            if (CurrentUser is null)
            {
                throw new Exception("You are not logged into any account.");
            }

            CurrentUser = null;
            Console.WriteLine("You have successfully logged out of your account.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}