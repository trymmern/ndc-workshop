namespace webAsync;

public class Program
{
    private const string Url = "https://jsonplaceholder.typicode.com/comments?postId=";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddHttpClient();
        
        var app = builder.Build();

        app.MapGet("/comments", async (IHttpClientFactory httpClientFactory) =>
        {
            var res = await RunAsync(httpClientFactory);
            var data = "";
            foreach (var message in res)
            {
                data += await message.Content.ReadAsStringAsync() + "\n\n";
            }
            return data;
        });

        app.Run();
    }

    private static async Task<HttpResponseMessage[]> RunAsync(IHttpClientFactory httpClientFactory)
    {
        var client = httpClientFactory.CreateClient();

        var tasks = new[]
        {
            client.GetAsync(Url + "1"),
            client.GetAsync(Url + "2"),
            client.GetAsync(Url + "3"),
            client.GetAsync(Url + "4")
        };

        var res = Task.WhenAll(tasks);
        
        await res.ContinueWith(t =>
        {
            Console.WriteLine(t.Exception);
        }, TaskContinuationOptions.OnlyOnFaulted).ContinueWith(t =>
        {
            Console.WriteLine(t.Status);
        }, TaskContinuationOptions.OnlyOnRanToCompletion);
        
        return await res;
        // RunInternalAsync(client);
    }

    // private static async Task<HttpResponseMessage> RunInternalAsync(HttpClient client)
    // {
    //     return await client.GetAsync("https://jsonplaceholder.typicode.com/comments?postId=1");
    // }
}
