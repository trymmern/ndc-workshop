namespace console2;
class Program
{
    static async Task Main(string[] args)
    {
        await ReadLinesAsync();
    }
    
    static async Task ReadLinesAsync()
    {
        var lines = ReadLinesInnerAsync();
        await foreach (var line in lines)
        {
            Console.WriteLine(line);
        }
    }
    
    static async IAsyncEnumerable<string> ReadLinesInnerAsync()
    {
        using var stream = new StreamReader(File.OpenRead(@"C:\dev\ndc-workshop\console2\lyrics.txt"));
        while (await stream.ReadLineAsync() is string line)
        {
            await Task.Delay(500);
            yield return line;
        }
    }
}
