using System.Diagnostics;
using Application.Error;
using Application.Event;
using Confluent.Kafka;
using FluentResults;
using Infra.Options;
using Microsoft.Extensions.Options;

namespace Application.MessageBroker;

public class DessertMessageBroker : IOrderMessageBroker<DessertOrderEvent>
{
    private readonly MessageBrokerOptions _messageOptions;
    private ProducerConfig Config { get; init; }

    public DessertMessageBroker( IOptions<MessageBrokerOptions> messageOptions)
    {
        _messageOptions = messageOptions.Value;
        Config = new ProducerConfig()
        {
            BootstrapServers = _messageOptions.OrderBrokerEndpoint
        };
    }

    public async Task<Result> Publish(DessertOrderEvent @event)
    {
        using (var p = new ProducerBuilder<Null, DessertOrderEvent>(Config).Build())
        {
            try
            {
                var dr = await p.ProduceAsync(
                    _messageOptions.Topics.KitchenAreaDessert, 
                    new Message<Null, DessertOrderEvent> { Value=@event }
                );

                return Result.Ok();
            }
            catch (ProduceException<Null, DessertOrderEvent> e)
            {
                return Result.Fail(new MessageBrokerError<DessertOrderEvent>(
                    ApplicationErrorMessages.DessertMessageBrokerError,
                    @event, 
                    e
                ));
            }
        }
    }
}