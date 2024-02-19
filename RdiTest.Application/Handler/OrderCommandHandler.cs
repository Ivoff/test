using Application.Command;
using FluentResults;

namespace Application.Handler;

public class OderCommandHandler : ICommandHandler<OrderCommand, Task<Result>>
{
    public async Task<Result> Handle(OrderCommand command, CancellationToken cancellationToken)
    {
        Console.WriteLine("Chegou aqui");
        return Result.Ok();
    }
}