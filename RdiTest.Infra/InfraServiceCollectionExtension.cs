using System.Text.Json.Serialization;
using Infra.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Infra;

public static class InfraServiceCollectionExtension
{
    public static WebApplicationBuilder AddInfra(this WebApplicationBuilder builder)
    {
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
        
        builder.Services.Configure<MessageBrokerOptions>(
            builder.Configuration.GetSection(MessageBrokerOptions.MessageBroker)
        );

        return builder;
    }

    public static IApplicationBuilder UseDevelopmentSettings(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpLogging();
        }
        
        return app;
    }
}