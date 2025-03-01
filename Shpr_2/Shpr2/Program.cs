namespace Shpr2;

class Program
{
    static void Main()
    {
        // Chain of responsibility
        var userManager = new UserManager();
        userManager.Registration("Alex", "Qwert91!");
        userManager.Logout();
        userManager.Logout();
        userManager.Authorisation("Alex", "Qwert91!");
        userManager.Authorisation("Alex", "Qwert91!");
        userManager.Logout();
        userManager.Authorisation("Michael", "!123321Qw");
        userManager.Registration("Alex", "Qwert91!");
    }
}