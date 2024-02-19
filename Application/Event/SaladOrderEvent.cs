using Core.OrderRequest;

namespace Application.Event;

public record SaladOrderEvent(Guid OrderId, List<SaladOrder> SaladOrders): IOrderEvent;