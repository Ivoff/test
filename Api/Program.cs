using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application;
using Microsoft.AspNetCore.Mvc.ModelBinding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(c =>
{
    c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    c.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging(o => { });

builder.Services.AddApplication();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpLogging();
}

// app.UseHttpsRedirection();

app.MapControllers();

app.Run();