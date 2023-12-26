//HttpClient client = new HttpClient(); // fetch()

//var json = await client.GetStringAsync("https://localhost:7104/api/users");

//Console.WriteLine(json);


var table = new List<Test>(){
    new Test(){A = "aaa", B = "bbb", C = "ccc"},
    new Test(){A = "xxx", B = "ggg", C = "qqq"},
    new Test(){A = "yyy", B = "hhh", C = "www"},
    new Test(){A = "zzz", B = "jjj", C = "rrr"},
};





//select A from table

var selected = table.Select(t => t.A).ToList();

//select A, B from table

var selected2 = table.Select(t => new Test2
{
    A = t.A,
    B = t.B,
}).ToList();

var sonuc = String.Join(", ",  selected);


Console.WriteLine(sonuc);

foreach (var item in selected2)
{
    Console.WriteLine(item.A + " " + item.B);
}

class Test
{
    public string A { get; set; }
    public string B { get; set; }
    public string C { get; set; }
}

class Test2
{
    public string A { get; set; }
    public string B { get; set; }
}