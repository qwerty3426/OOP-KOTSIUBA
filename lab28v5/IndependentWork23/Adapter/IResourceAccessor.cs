namespace IndependentWork23.Adapter;

public interface IResourceAccessor
{
    string Access(string resourceId, string token);
}