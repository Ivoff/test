using Core.Enums;
using Core.OrderRequest;
using FluentResults;

namespace Core.Builder;

/*
 * Using the Builder pattern for extendability. If there is the need for having specific orders like combos, this can
 * be used
 */

public interface IOrderBuilder
{
    public IOrderBuilder AddId(Guid id);
    public IOrderBuilder AddDessertOrder(DessertType dessertType, int portionQuantity);
    public IOrderBuilder AddFriesOrder(FriesSize friesSize, int portionQuantity);
    public IOrderBuilder AddGrillOrder(BunSize bunSize, BunType bunType, BurgerType burgerType, int portionQuantity);
    public IOrderBuilder AddSaladOrder(List<SaladOrderComponent> components, int quantity);
    public Result<Order> Build();
}