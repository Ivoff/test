using Core.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class CoreServiceCollectionExtension
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<OrderBuilderDirector<OrderBuilder>>();

        return services;
    }
}