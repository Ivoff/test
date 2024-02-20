using Core.Enums;

namespace Core.OrderRequest;

public sealed record DrinkOrder(DrinkType DrinkType, DrinkSize DrinkSize, int PortionQuantity) : RequestPortionOrder(PortionQuantity);