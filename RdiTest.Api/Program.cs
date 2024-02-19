using Application;
using Infra;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplication();
builder.AddInfra();

var app = builder.Build();
app.UseDevelopmentSettings();

app.MapControllers();

app.Run();