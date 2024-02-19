using Application.Command;
using Application.Handler;
using FluentResults;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<OrderCommand, Task<Result>>, OderCommandHandler>();
        
        return services;
    }
}