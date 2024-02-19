using Core.Enums;
using Core.OrderRequest;
using FluentResults;

namespace Core.Builder;

public interface IOrderBuilder
{
    public IOrderBuilder AddId(Guid id);
    public IOrderBuilder AddId();
    public IOrderBuilder AddDessertOrder(DessertType dessertType, int portionQuantity);
    public IOrderBuilder AddFriesOrder(FriesSize friesSize, int portionQuantity);
    public IOrderBuilder AddGrillOrder(BunSize bunSize, BunType bunType, BurgerType burgerType, int portionQuantity);
    public IOrderBuilder AddSaladOrder(List<SaladOrderComponent> components, int quantity);
    public Result<Order> Build();
}