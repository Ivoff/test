using Core.OrderRequest;

namespace Application.Command;

public record OrderCommand
{
    public List<DessertOrder> DessertOrders;
    public List<FriesOrder> FriesOrders;
    public List<GrillOrder> GrillOrders;
    public List<DrinkOrder> DrinkOrders;
    public List<SaladOrder> SaladOrders;

    public OrderCommand(
        List<DessertOrder> dessertOrders, 
        List<FriesOrder> friesOrders, 
        List<GrillOrder> grillOrders, 
        List<DrinkOrder> drinkOrders, 
        List<SaladOrder> saladOrders)
    {
        DessertOrders = dessertOrders;
        FriesOrders = friesOrders;
        GrillOrders = grillOrders;
        DrinkOrders = drinkOrders;
        SaladOrders = saladOrders;
    }
};