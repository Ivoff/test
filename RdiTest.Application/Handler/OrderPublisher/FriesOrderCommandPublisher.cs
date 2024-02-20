// using Application.Command.Messages;
// using Core;
// using FluentResults;
// using Infra;
// using Infra.Options;
// using MassTransit;
//
// namespace Application.Handler.OrderPublisher;
//
// public class FriesOrderCommandPublisher: IMessageCommandPublisher<Order, Result<List<CreateFriesOrderCommand>>>
// {
//     private readonly QueuesOptions _options;
//     private readonly IBus _bus;
//
//     public FriesOrderCommandPublisher(QueuesOptions options, IBus bus)
//     {
//         _options = options;
//         _bus = bus;
//     }
//     
//     public async Task<Result<List<CreateFriesOrderCommand>>> Publish(Order entity, CancellationToken cancellationToken)
//     {
//         try
//         {
//             var endpoint = await _bus.GetSendEndpoint(new Uri(_options.KitchenAreaFries));
//         
//             var friesOrderCommands = entity.FriesOrders
//                 .Select(x => new CreateFriesOrderCommand(entity.Id, DateTime.UtcNow, x))
//                 .ToList();
//         
//             var friesOrderTasks = friesOrderCommands.Select(x => endpoint.Send(x, cancellationToken)).ToList();
//
//             await Task.WhenAll(friesOrderTasks);
//
//             return friesOrderCommands;
//         }
//         catch (Exception e)
//         {
//             return new Result<List<CreateFriesOrderCommand>>()
//                 .WithError(ApplicationErrorMessages.MessagePublishError.Replace("{ORDER}", "Drink"))
//                 .WithReason(new FluentResults.Error(e.Message).CausedBy(e));
//         }
//     }
// }