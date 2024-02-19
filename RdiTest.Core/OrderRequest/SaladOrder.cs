using Core.Enums;

namespace Core.OrderRequest;

public sealed record SaladOrderComponent(SaladComponent Component, int PortionQuantity);

public sealed record SaladOrder(List<SaladOrderComponent> Components, int Quantity);