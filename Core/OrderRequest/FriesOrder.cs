using Core.Enums;

namespace Core.OrderRequest;

public sealed record FriesOrder(FriesSize FriesSize, int PortionQuantity)
    : RequestPortionOrder(PortionQuantity)
{ 
    public FriesSize FriesSize { get; } = FriesSize;
}