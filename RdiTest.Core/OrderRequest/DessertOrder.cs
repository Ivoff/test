using Core.Enums;

namespace Core.OrderRequest;

public sealed record DessertOrder(DessertType DessertType, int PortionQuantity) : RequestPortionOrder(PortionQuantity);