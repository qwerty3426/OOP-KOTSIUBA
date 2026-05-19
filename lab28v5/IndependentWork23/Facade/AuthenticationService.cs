namespace IndependentWork23.Facade;

public class AuthenticationService
{
    public bool Login(string user, string password)
    {
        return user == "admin" && password == "1234";
    }
}