var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();


app.MapGet("/merhaba", () => "Merhaba dünya!");
app.MapGet("/merhaba2", MerhabaDe);


app.MapGet("/topla/{s1}/{s2}", (int s1, int s2) =>
{
    return Topla(s1, s2);   
});

app.Run();


string Topla(int s1, int s2)
{
    return $"Toplam: {s1 + s2}";
}


string MerhabaDe()
{
    return "Merhaba dünya 2";
}
