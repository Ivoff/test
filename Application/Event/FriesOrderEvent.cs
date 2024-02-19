using Core.OrderRequest;

namespace Application.Event;

public record FriesOrderEvent(Guid OrderId, List<FriesOrder> FriesOrders): IOrderEvent;