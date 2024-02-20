using FluentResults;
using Infra.Options;
using MassTransit;
using Microsoft.Extensions.Options;

namespace Application.Handler;

public interface IMessagePublisher<T>
{
    Task<Result> Publish(T entity, CancellationToken cancellationToken);
}