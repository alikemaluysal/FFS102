HttpClient client = new HttpClient();


var json = await client.GetStringAsync("https://localhost:7104/api/users");

Console.WriteLine(json);