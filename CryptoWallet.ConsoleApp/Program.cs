using System.Text;

var result1 = Task.Run(() => GetTrans("3", "8", "USDT", "1111"));
var result2 = Task.Run(() => GetTrans("2", "5", "BTC", "5"));
var result3 = Task.Run(() => GetTrans("1", "6", "BTC", "12"));

Task.WaitAll();

Console.WriteLine(result1);
Console.WriteLine(result2);
Console.WriteLine(result3);

async Task<string> GetTrans(string senderId, string recipientId, string coin, string count)
{
    var client = new HttpClient();

    var message = new HttpRequestMessage();
    message.Headers.Add("Accept", "application/json");
    message.RequestUri = new Uri("https://localhost:7002" + $"/api/transaction/{senderId} {recipientId} {coin} {count}");

    client.DefaultRequestHeaders.Clear();

    HttpResponseMessage apiResponse = null;

    message.Method = HttpMethod.Post;

    apiResponse = await client.SendAsync(message);

    return await apiResponse.Content.ReadAsStringAsync();
}