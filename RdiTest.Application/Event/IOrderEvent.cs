namespace Application.Event;

public interface IOrderEvent
{
    public Guid OrderId { get; init; }
}