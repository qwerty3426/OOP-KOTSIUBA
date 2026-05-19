using IndependentWork23.Adapter;

namespace IndependentWork23.Facade;

public class ResourceFacade
{
    private readonly AuthenticationService _auth = new();
    private readonly AuthorizationService _authz = new();
    private readonly IResourceAccessor _accessor = new ResourceAccessAdapter();

    public string Access(string user, string password, string resourceId)
    {
        if (!_auth.Login(user, password))
            return "❌ Login failed";

        if (!_authz.CheckPermission(user, resourceId))
            return "❌ Access denied";

        return _accessor.Access(resourceId, "secure-token");
    }
}