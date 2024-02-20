// using Application.Command.Messages;
// using Core;
// using FluentResults;
// using Infra;
// using Infra.Options;
// using MassTransit;
// using Microsoft.Extensions.Options;
//
// namespace Application.Handler.OrderPublisher;
//
// public class DessertOrderCommandPublisher: IMessageCommandPublisher<Order, Result<List<CreateDessertOrderCommand>>>
// {
//     private readonly QueuesOptions _options;
//     private readonly IBus _bus;
//
//     public DessertOrderCommandPublisher(IOptions<QueuesOptions> options, IBus bus)
//     {
//         _options = options.Value;
//         _bus = bus;
//     }
//
//     public async Task<Result<List<CreateDessertOrderCommand>>> 
//         Publish(Order entity, CancellationToken cancellationToken)
//     {
//         try
//         {
//             var endpoint = await _bus.GetSendEndpoint(new Uri(_options.KitchenAreaDessert));
//         
//             var desertOrderCommands = entity.DessertOrders
//                 .Select(x => new CreateDessertOrderCommand(entity.Id, DateTime.UtcNow, x))
//                 .ToList();
//         
//             var desertOrderTasks = desertOrderCommands.Select(x => endpoint.Send(x, cancellationToken)).ToList();
//
//             await Task.WhenAll(desertOrderTasks);
//
//             return desertOrderCommands;
//         }
//         catch (Exception e)
//         {
//             return new Result<List<CreateDessertOrderCommand>>()
//                 .WithError(InfraErrorMessages.MessagePublishError.Replace("{ORDER}", "Dessert"))
//                 .WithReason(new FluentResults.Error(e.Message).CausedBy(e));
//         }
//     }
// }