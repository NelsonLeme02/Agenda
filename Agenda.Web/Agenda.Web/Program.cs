using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", async context =>
{
    var filePath = Path.Combine(builder.Environment.ContentRootPath, "views", "home", "Home.html");
    var content = await File.ReadAllTextAsync(filePath);
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(content);
});

app.Run();
