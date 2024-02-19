using Core.OrderRequest;

namespace Application.Command;

public record OrderCommand(
    IList<DessertOrder> DessertOrders,
    IList<FriesOrder> FriesOrders,
    IList<GrillOrder> GrillOrders,
    IList<SaladOrder> SaladOrders
);