using Core.OrderRequest;

namespace Application.Command.Messages;

public record CreateSaladOrderCommand(
    Guid OrderId,
    DateTime CreatedAt,
    SaladOrder SaladOrder
) : ICreateOrderCommand;