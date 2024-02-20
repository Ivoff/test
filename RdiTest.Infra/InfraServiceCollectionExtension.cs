using System.Text.Json.Serialization;
using Infra.Options;
using Infra.Publisher;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
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
            // c.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        });
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHttpLogging(o => { });
        
        var brokerOptions = builder.Configuration.GetSection(BrokerOptions.SectionName).Get<BrokerOptions>()!;
        builder.Services.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq((context, config) =>
            {
                config.Host(
                    brokerOptions.Host,
                    brokerOptions.Port,
                    "/",
                    h =>
                    {
                        h.Username(brokerOptions.User);
                        h.Password(brokerOptions.Password);
                    }
                );
            });
        });
        
        builder.Services.Configure<QueuesOptions>(builder.Configuration.GetSection(QueuesOptions.SectionName));
        builder.Services.Configure<BrokerOptions>(builder.Configuration.GetSection(BrokerOptions.SectionName));
        builder.Services.AddScoped<IMessagePublisher, MessagePublisher>();
        
        
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