using Confluent.Kafka;
using FluentResults;

namespace Application.Error;

public class MessageBrokerError<T> : IError
{
    public string Message { get; }
    public Dictionary<string, object> Metadata { get; } = new Dictionary<string, object>();
    public List<IError> Reasons { get; } = new List<IError>();
    
    public T Event { get; init; }
    public ProduceException<Null, T> Exception { get; init; }

    public MessageBrokerError(string message, T @event, ProduceException<Null, T> exception)
    {
        Message = message;
        Event = @event;
        Exception = exception;
    }
}
