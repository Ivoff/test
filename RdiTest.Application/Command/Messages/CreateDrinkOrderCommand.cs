using Core.OrderRequest;

namespace Application.Command.Messages;

public record CreateDrinkOrderCommand(
    Guid OrderId,
    DateTime CreatedAt,
    DrinkOrder DrinkOrder
): ICreateOrderCommand;