using Application.Command;
using Application.Handler;
using FluentResults;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceCollectionExtension
{
    public static WebApplicationBuilder AddApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICommandHandler<OrderCommand, Task<Result>>, OderCommandHandler>();
        
        return builder;
    }
}