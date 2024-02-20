using Application.Command;
using Application.Handler.OrderCommandHandler;
using FluentResults;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceCollectionExtension
{
    public static WebApplicationBuilder AddApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICommandHandler<OrderCommand, Task<Result>>, OderCommandHandler>();
        // builder.Services.AddScoped<IMessageCommandPublisher<Order, Result<List<CreateDessertOrderCommand>>>,
        //     DessertOrderCommandPublisher>();
        // builder.Services.AddScoped<IMessageCommandPublisher<Order, Result<List<CreateDrinkOrderCommand>>>, 
        //     DrinkOrderCommandPublisher>();
        // builder.Services.AddScoped<IMessageCommandPublisher<Order, List<CreateFriesOrderCommand>>, 
        //     FriesOrderCommandPublisher>();
        // builder.Services.AddScoped<IMessageCommandPublisher<Order, List<CreateGrillOrderCommand>>, 
        //     GrillOrderCommandPublisher>();
        // builder.Services.AddScoped<IMessageCommandPublisher<Order, List<CreateSaladOrderCommand>>,
        //     SaladOrderCommandPublisher>();
        
        return builder;
    }
}