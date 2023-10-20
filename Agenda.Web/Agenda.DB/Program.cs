using Agenda.DB.Config.Interface;
using Agenda.DB.Config.Service;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddSingleton<IMongoDBService, MongoDBService>();

app.MapGet("/", () => "Hello World!");

app.Run();
