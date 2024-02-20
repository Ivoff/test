using Core;
using Core.Builder;
using FluentResults;
using Infra.Publisher;

namespace Application.Handler.OrderCommandHandler;

/*
 * I'm gonna disregard immutability to build the order domain object.
 * Probably not the best design choice here, in the Application layer, but it would payoff if the business rules were
 * more complex, since their validation would be separated and encapsulated in the domain and the result of the validation
 * would be delivered in a single object.
 */

public class OderCommandHandler : ICommandHandler<Command.OrderCommand, Task<Result>>
{
    private OrderBuilder _orderBuilder;
    private readonly IMessagePublisher _messagePublisher;

    public OderCommandHandler( 
        OrderBuilderDirector<OrderBuilder> orderBuilderDirector, 
        IMessagePublisher messagePublisher)
    {
        _messagePublisher = messagePublisher;
        _orderBuilder = orderBuilderDirector.Builder;
    }
    
    public async Task<Result> Handle(Command.OrderCommand command, CancellationToken cancellationToken)
    {
        var orderResult = BuildOrder(command);

        if (orderResult.IsFailed)
            return new Result().WithErrors(orderResult.Errors).WithReasons(orderResult.Reasons);

        var order = orderResult.Value;

        var orderTasks = order.DessertOrders.Select(dessertOrder => _messagePublisher.Publish(dessertOrder, cancellationToken))
            .Union(order.DrinkOrders.Select(drinkOrder => _messagePublisher.Publish(drinkOrder, cancellationToken)))
            .Union(order.FriesOrders.Select(friesOrder => _messagePublisher.Publish(friesOrder, cancellationToken)))
            .Union(order.SaladOrders.Select(saladOrder => _messagePublisher.Publish(saladOrder, cancellationToken)))
            .Union(order.GrillOrders.Select(grillOrder => _messagePublisher.Publish(grillOrder, cancellationToken)))
            .ToList();

        var results = await Task.WhenAll(orderTasks);

        return results.Merge();
    }

    private Result<Order> BuildOrder(Command.OrderCommand command)
    {
        foreach (var dessertOrder in command.DessertOrders)
        {
            _orderBuilder = (OrderBuilder)_orderBuilder
                .AddDessertOrder(dessertOrder.DessertType, dessertOrder.PortionQuantity);
        }
        
        foreach (var friesOrder in command.FriesOrders)
        {
            _orderBuilder = (OrderBuilder)_orderBuilder
                .AddFriesOrder(friesOrder.FriesSize, friesOrder.PortionQuantity);
        }

        foreach (var grillOrder in command.GrillOrders)
        {
            _orderBuilder = (OrderBuilder)_orderBuilder.AddGrillOrder(
                grillOrder.BunSize, 
                grillOrder.BunType, 
                grillOrder.BurgerType, 
                grillOrder.PortionQuantity);
        }
        
        foreach (var drinkOrder in command.DrinkOrders)
        {
            _orderBuilder = (OrderBuilder)_orderBuilder.AddDrinkOrder(
                drinkOrder.DrinkType, 
                drinkOrder.DrinkSize, 
                drinkOrder.PortionQuantity);
        }
        
        foreach (var saladOrder in command.SaladOrders)
        {
            _orderBuilder = (OrderBuilder)_orderBuilder
                .AddSaladOrder(saladOrder.Components, saladOrder.Quantity);
        }

        return _orderBuilder.Build();
    }
}