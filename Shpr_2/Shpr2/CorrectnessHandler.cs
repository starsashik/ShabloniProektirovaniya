namespace Shpr2;

public class CorrectnessHandler : Handler
{
    public override void HandleRequest(string username, string password, List<User> users, User? curUser)
    {
        if (!(username.Length < 2 || username.Length > 20) && !username.Any(char.IsPunctuation))
        {
            if (!(password.Length < 2 || password.Length > 20) && password.Any(char.IsPunctuation)
                && password.Any(char.IsLetter)
                && password.Any(char.IsDigit)
                && password.Any(char.IsUpper)
                && password.Any(char.IsLower))
            {
                Successor?.HandleRequest(username, password, users, curUser);
                return;
            }

            throw new Exception($"Your password: {password} is not correct.");
        }
        throw new Exception($"Your username {username} is not correct.");
    }
}