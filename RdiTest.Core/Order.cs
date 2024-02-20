using Core.Builder;
using Core.OrderRequest;

namespace Core;

public partial class Order
{
    public Guid Id { get; init; }
    public IList<DessertOrder> DessertOrders { get; init; }
    public IList<FriesOrder> FriesOrders { get; init; }
    public IList<GrillOrder> GrillOrders { get; init; }
    public IList<SaladOrder> SaladOrders { get; init; }
}

public partial class Order
{
    
}
