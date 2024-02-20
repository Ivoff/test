namespace Application.Command.Messages;

public interface ICreateOrderCommand
{
    Guid OrderId { get; init; }
    DateTime CreatedAt { get; init; }
}