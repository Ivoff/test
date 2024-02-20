// using Application.Command.Messages;
// using Core;
// using Infra.Options;
// using MassTransit;
//
// namespace Application.Handler.OrderPublisher;
//
// public class GrillOrderCommandPublisher : IMessageCommandPublisher<Order, List<CreateGrillOrderCommand>>
// {
//     private readonly QueuesOptions _options;
//     private readonly IBus _bus;
//
//     public GrillOrderCommandPublisher(QueuesOptions options, IBus bus)
//     {
//         _options = options;
//         _bus = bus;
//     }
//     
//     public async Task<List<CreateGrillOrderCommand>> Publish(Order entity, CancellationToken cancellationToken)
//     {
//         var endpoint = await _bus.GetSendEndpoint(new Uri(_options.KitchenAreaGrill));
//         
//         var grillOrderCommands = entity.GrillOrders
//             .Select(x => new CreateGrillOrderCommand(entity.Id, DateTime.UtcNow, x))
//             .ToList();
//         
//         var grillOrderTasks = grillOrderCommands.Select(x => endpoint.Send(x, cancellationToken)).ToList();
//
//         await Task.WhenAll(grillOrderTasks);
//
//         return grillOrderCommands;
//     }
// }