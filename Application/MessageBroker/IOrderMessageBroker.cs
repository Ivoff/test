using Application.Event;
using FluentResults;

namespace Application.MessageBroker;

public interface IOrderMessageBroker<T> where T : IOrderEvent
{
    Task<Result> Publish(T @event);
}