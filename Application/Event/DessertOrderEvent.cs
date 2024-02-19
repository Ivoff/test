using Core.OrderRequest;

namespace Application.Event;

public record DessertOrderEvent(Guid OrderId, List<DessertOrder> DessertOrders): IOrderEvent;