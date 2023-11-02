using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configura��o para servir arquivos est�ticos da pasta "scripts" e "views/CSS"
builder.Services.AddDirectoryBrowser();

var app = builder.Build();

// Configura��o para servir arquivos est�ticos
app.UseStaticFiles();

// Configura��o para servir arquivos da pasta "views"
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "views")),
    RequestPath = "/views",
});

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "scripts")),
    RequestPath = "/scripts",
});

app.MapGet("/", async context =>
{
    var filePath = Path.Combine(builder.Environment.ContentRootPath, "views", "home", "Home.html");
    var content = await File.ReadAllTextAsync(filePath);
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(content);
});

app.Run();
