using FluentResults;
using MassTransit;

namespace Infra.Publisher;

public class MessagePublisher: IMessagePublisher
{
    private readonly IBus _bus;

    public MessagePublisher(IBus bus)
    {
        _bus = bus;
    }

    public async Task<Result> Publish<T>(T entity, CancellationToken cancellationToken) 
    {
        try
        {
            if (entity is not null) 
                await _bus.Publish(entity, cancellationToken);
            return Result.Ok();
        }
        catch (Exception e)
        {
            return new Result()
                .WithError(new Error(InfraErrorMessages.MessagePublishError.Replace("{ORDER}", nameof(T)))
                    .CausedBy(e));
        }
    }
}