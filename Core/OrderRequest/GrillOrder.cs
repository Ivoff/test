using Core.Enums;

namespace Core.OrderRequest;

public sealed record GrillOrder(BunSize BunSize, BunType BunType, BurgerType BurgerType, int PortionQuantity)
    : RequestPortionOrder(PortionQuantity)
{
    public BunSize BunSize { get; } = BunSize;
    public BunType BunType { get; } = BunType;
    public BurgerType BurgerType { get; } = BurgerType;
} 