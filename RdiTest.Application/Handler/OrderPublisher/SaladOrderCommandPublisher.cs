// using Application.Command.Messages;
// using Core;
// using Infra.Options;
// using MassTransit;
//
// namespace Application.Handler.OrderPublisher;
//
// public class SaladOrderCommandPublisher : IMessageCommandPublisher<Order, List<CreateSaladOrderCommand>>
// {
//     private readonly QueuesOptions _options;
//     private readonly IBus _bus;
//
//     public SaladOrderCommandPublisher(QueuesOptions options, IBus bus)
//     {
//         _options = options;
//         _bus = bus;
//     }
//     
//     public async Task<List<CreateSaladOrderCommand>> Publish(Order entity, CancellationToken cancellationToken)
//     {
//         var endpoint = await _bus.GetSendEndpoint(new Uri(_options.KitchenAreaSalad));
//         
//         var saladOrderCommands = entity.SaladOrders
//             .Select(x => new CreateSaladOrderCommand(entity.Id, DateTime.UtcNow, x))
//             .ToList();
//         
//         var saladOrderTasks = saladOrderCommands.Select(x => endpoint.Send(x, cancellationToken)).ToList();
//
//         await Task.WhenAll(saladOrderTasks);
//
//         return saladOrderCommands;
//     }
// }