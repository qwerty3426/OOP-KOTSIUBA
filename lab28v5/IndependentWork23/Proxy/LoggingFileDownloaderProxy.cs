namespace IndependentWork23.Proxy;

public class LoggingFileDownloaderProxy : IFileDownloader
{
    private readonly RealFileDownloader _real = new();

    private readonly Dictionary<string, string> _cache = new();
    private int _requestCount = 0;
    private const int LIMIT = 3;

    public string Download(string fileName)
    {
        _requestCount++;

        // 🔒 Ліміт запитів
        if (_requestCount > LIMIT)
            return "❌ Limit exceeded (proxy blocked request)";

        // ⚡ Кеш
        if (_cache.ContainsKey(fileName))
        {
            return $"⚡ FROM CACHE: {_cache[fileName]}";
        }

        Console.WriteLine($"[LOG] Download request: {fileName}");

        var result = _real.Download(fileName);

        _cache[fileName] = result;

        Console.WriteLine($"[LOG] Cached: {fileName}");

        return result;
    }
}