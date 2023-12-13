HttpClient client = new HttpClient(); // fetch()

var json = await client.GetStringAsync("https://localhost:7104/api/users");

Console.WriteLine(json);