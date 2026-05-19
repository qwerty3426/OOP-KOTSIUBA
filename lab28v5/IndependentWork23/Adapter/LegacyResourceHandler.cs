namespace IndependentWork23.Adapter;

public class LegacyResourceHandler
{
    public string AccessResource(string resourceId, string token)
    {
        return $"[LEGACY] Resource={resourceId}, Token={token}";
    }
}