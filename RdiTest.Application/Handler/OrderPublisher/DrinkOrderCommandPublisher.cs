// using Application.Command.Messages;
// using Core;
// using FluentResults;
// using Infra;
// using Infra.Options;
// using MassTransit;
//
// namespace Application.Handler.OrderPublisher;
//
// public class DrinkOrderCommandPublisher : IMessageCommandPublisher<Order, Result<List<CreateDrinkOrderCommand>>>
// {
//     private readonly QueuesOptions _options;
//     private readonly IBus _bus;
//
//     public DrinkOrderCommandPublisher(QueuesOptions options, IBus bus)
//     {
//         _options = options;
//         _bus = bus;
//     }
//
//     public async Task<Result<List<CreateDrinkOrderCommand>>> Publish(Order entity, CancellationToken cancellationToken)
//     {
//         try
//         {
//             var endpoint = await _bus.GetSendEndpoint(new Uri(_options.KitchenAreaDrink));
//         
//             var drinkOrderCommands = entity.DrinkOrders
//                 .Select(x => new CreateDrinkOrderCommand(entity.Id, DateTime.UtcNow, x))
//                 .ToList();
//         
//             var drinkOrderTasks = drinkOrderCommands.Select(x => endpoint.Send(x, cancellationToken)).ToList();
//
//             await Task.WhenAll(drinkOrderTasks);
//
//             return drinkOrderCommands;
//         }
//         catch (Exception e)
//         {
//             return new Result<List<CreateDrinkOrderCommand>>()
//                 .WithError(InfraErrorMessages.MessagePublishError.Replace("{ORDER}", "Drink"))
//                 .WithReason(new FluentResults.Error(e.Message).CausedBy(e));
//         }
//     }
// }