using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapStaticAssets();

app.MapGet("/images/{imageName}", async (string imageName) =>
{
    Console.WriteLine("delay for cache");
    
    await Task.Delay(1000);
    Console.WriteLine(imageName);

    // db lookup 
    var filePath = "/app/Api/wwwroot/images/woienfaofinewaofin";

    byte[] fileContents = System.IO.File.ReadAllBytes(filePath);

    var mimeType = imageName switch
    {
        string name when name.EndsWith(".png", StringComparison.OrdinalIgnoreCase) => "image/png",
        string name when name.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) => "image/jpeg",
        string name when name.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) => "image/jpeg",
        _ => "unsupported"
    };

    return Results.File(fileContents, "image/png", "image.png");
});

app.MapGet("/", () => "Hello World!");

app.MapGet("/health", () => "yay! healthy!!! 🔥");
app.MapGet("/api/delay", async () =>
{
    Console.WriteLine("sleeping for delay");

    await Task.Delay(2000);
    return "yay! delay!!! 🔥";
});

app.Run();
