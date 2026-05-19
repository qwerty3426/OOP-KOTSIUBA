namespace IndependentWork23.Adapter;

public class ResourceAccessAdapter : IResourceAccessor
{
    private readonly LegacyResourceHandler _legacy = new();

    public string Access(string resourceId, string token)
    {
        return _legacy.AccessResource(resourceId, token);
    }
}