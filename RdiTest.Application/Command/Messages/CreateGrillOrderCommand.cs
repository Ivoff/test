using Core.OrderRequest;

namespace Application.Command.Messages;

public record CreateGrillOrderCommand(
    Guid OrderId,
    DateTime CreatedAt,
    GrillOrder GrillOrder
) : ICreateOrderCommand;