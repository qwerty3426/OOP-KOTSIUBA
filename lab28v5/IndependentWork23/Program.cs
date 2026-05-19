using IndependentWork23.Adapter;
using IndependentWork23.Facade;
using IndependentWork23.Proxy;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== VARIANT 19: Adapter + Facade + Proxy ===\n");

        // ======================
        // FACADE
        // ======================
        var facade = new ResourceFacade();

        Console.WriteLine("🔐 FACADE:");
        Console.WriteLine(facade.Access("admin", "1234", "file1"));
        Console.WriteLine(facade.Access("admin", "1234", "file2"));

        Console.WriteLine("\n----------------------\n");

        // ======================
        // PROXY
        // ======================
        Console.WriteLine("📦 PROXY:");

        IFileDownloader downloader = new LoggingFileDownloaderProxy();

        Console.WriteLine(downloader.Download("big.zip"));
        Console.WriteLine(downloader.Download("big.zip")); // cache
        Console.WriteLine(downloader.Download("video.mp4"));
        Console.WriteLine(downloader.Download("file1"));
        Console.WriteLine(downloader.Download("file2")); // limit

        Console.WriteLine("\n----------------------\n");

        // ======================
        // ADAPTER
        // ======================
        Console.WriteLine("🔄 ADAPTER:");

        var adapter = new ResourceAccessAdapter();
        Console.WriteLine(adapter.Access("legacy_resource", "token-999"));
    }
}