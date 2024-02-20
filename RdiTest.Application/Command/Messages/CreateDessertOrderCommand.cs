using Core.OrderRequest;

namespace Application.Command.Messages;

public record CreateDessertOrderCommand(
    Guid OrderId,
    DateTime CreatedAt,
    DessertOrder DessertOrder
): ICreateOrderCommand;