using FluentResults;

namespace Infra.Publisher;

public interface IMessagePublisher
{
    Task<Result> Publish<T>(T entity, CancellationToken cancellationToken);
}