using Agenda.Services.Interfaces;
using Agenda.Services.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddSingleton<IContatoService, ContatoService>();
app.MapGet("/", () => "Hello World!");

app.Run();
