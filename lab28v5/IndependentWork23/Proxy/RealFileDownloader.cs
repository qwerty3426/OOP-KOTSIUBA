namespace IndependentWork23.Proxy;

public class RealFileDownloader : IFileDownloader
{
    public string Download(string fileName)
    {
        return $"DOWNLOAD_RESULT:{fileName}";
    }
}