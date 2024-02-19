/*
 * Each kitchen area have a collection of orders designated, so it is possible to two orders for the same kitchen area.
 * Each kitchen area order have a portion quantity attributed to it.
 * The salad kitchen area order is an outlier, each order is composed of salad components.
 * I'm not checking for uniqueness of order combinations. For example, having two separate orders for the grill area
 * that are identical to each other.
 * As I'm using the builder pattern here, it can be extended to contemplate discrete menus.
 * I'm also setting the result pattern for domain entity building. The use of it here is rather messy and could be
 * altered to be more useful. For example, properly defining domain errors for each error in a manner that allows
 * the error to contain the data useful for the application layer to deal with and send back to the client.
 */

using Core.Enums;
using Core.Error;
using Core.OrderRequest;
using FluentResults;

namespace Core.Builder;

public class OrderBuilder : IOrderBuilder
{
    private Guid _id;
    private IList<DessertOrder> _dessertOrders = new List<DessertOrder>();
    private IList<FriesOrder> _friesOrders = new List<FriesOrder>();
    private IList<GrillOrder> _grillOrders = new List<GrillOrder>();
    private IList<SaladOrder> _saladOrders = new List<SaladOrder>();

    private List<Result> _results = new List<Result>();

    public IOrderBuilder AddId(Guid id)
    {
        _id = id;
        return this;
    }

    public IOrderBuilder AddId()
    {
        _id = Guid.NewGuid();
        return this;
    }

    private Result PortionQuantityChecker(int portionQuantity, int index, string subject)
    {
        return Result.FailIf(
            portionQuantity <= 0,
            new OrderError(CoreErrorMessages.PORTION_QUANTITY_ZERO, _id, index, 0, subject)
        );
    }
    
    private Result SaladComponentPortionQuantityChecker
        (IList<SaladOrderComponent> components, int index)
    {
        var result = components.FirstOrDefault(x => x.PortionQuantity <= 0);

        return Result.FailIf(
            result == null,
            new OrderError(
                CoreErrorMessages.SALAD_COMPONENT_PORTION_QUANTITY_ZERO,
                _id,
                index,
                components.IndexOf(result!),
                result!.Component.ToString()
            )
        );
    }
    
    public IOrderBuilder AddDessertOrder(DessertType dessertType, int portionQuantity)
    {
        _results.Add(
            PortionQuantityChecker(portionQuantity, 
            _dessertOrders.Count, 
            $"{nameof(DessertType)} {dessertType}")
        );
        
        if (_results.Last().IsSuccess)
            _dessertOrders.Add(new DessertOrder(dessertType, portionQuantity));
        
        return this;
    }

    public IOrderBuilder AddFriesOrder(FriesSize friesSize, int portionQuantity)
    {
        _results.Add(
            PortionQuantityChecker(portionQuantity, 
                _friesOrders.Count, 
            $"{nameof(FriesSize)} {friesSize}")
        );
        
        if (_results.Last().IsSuccess)
            _friesOrders.Add(new FriesOrder(friesSize, portionQuantity));
        
        return this;
    }

    public IOrderBuilder AddGrillOrder(BunSize bunSize, BunType bunType, BurgerType burgerType, int portionQuantity)
    {
        _results.Add(
            PortionQuantityChecker(portionQuantity, 
            _grillOrders.Count, 
            $"{nameof(BunSize)} {bunSize} | {nameof(BunType)} {bunType} | {nameof(BurgerType)} | {burgerType}")
        );
        
        if (_results.Last().IsSuccess)
            _grillOrders.Add(new GrillOrder(bunSize, bunType, burgerType, portionQuantity));
        
        return this;
    }

    public IOrderBuilder AddSaladOrder(List<SaladOrderComponent> components, int quantity)
    {
        _results.Add(SaladComponentPortionQuantityChecker(components, _saladOrders.Count));

        if (_results.Last().IsSuccess)
            _saladOrders.Add(new SaladOrder(components, quantity));
        
        return this;
    }

    public Result<Order> Build()
    {
        var buildResult = _results.Merge();

        return buildResult.IsSuccess 
            ? new Order() 
            { 
                Id = _id,
                DessertOrders = _dessertOrders,
                FriesOrders = _friesOrders,
                GrillOrders = _grillOrders,
                SaladOrders = _saladOrders
            } 
            : buildResult;
    }
}