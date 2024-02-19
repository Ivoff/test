using Core.Enums;

namespace Core.OrderRequest;

public sealed record GrillOrder(BunSize BunSize, BunType BunType, BurgerType BurgerType, int PortionQuantity) 
    : RequestPortionOrder(PortionQuantity);