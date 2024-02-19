using Core.OrderRequest;

namespace Application.Event;

public record GrillOrderEvent(Guid OrderId, List<GrillOrder> GrillOrders) : IOrderEvent;
