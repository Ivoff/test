using Application;
using Core;
using Infra;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplication();
builder.Services.AddCore();
builder.AddInfra();

var app = builder.Build();
app.UseDevelopmentSettings();

app.MapControllers();

app.Run();