using Core.OrderRequest;

namespace Application.Command.Messages;

public record CreateFriesOrderCommand(
    Guid OrderId, 
    DateTime CreatedAt,
    FriesOrder FriesOrder
) : ICreateOrderCommand;

