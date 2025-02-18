var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/health", () => "yay! healthy!!! 🔥");
app.MapGet("/api/delay", async () =>
{
    Console.WriteLine("sleeping for delay");
    
    await Task.Delay(2000);
    return "yay! delay!!! 🔥";
});

app.Run();
