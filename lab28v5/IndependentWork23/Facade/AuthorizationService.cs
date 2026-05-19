namespace IndependentWork23.Facade;

public class AuthorizationService
{
    public bool CheckPermission(string user, string resourceId)
    {
        return user == "admin";
    }
}