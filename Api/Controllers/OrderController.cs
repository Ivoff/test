using Application;
using Application.Command;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : BasicController
{
    private readonly ICommandHandler<OrderCommand, Task<Result>> _commandHandler;
    
    public OrderController(ICommandHandler<OrderCommand, Task<Result>> commandHandler)
    {
        _commandHandler = commandHandler;
    }

    [HttpPost]
    public async Task<IActionResult> PostOrder([FromForm] OrderCommand command, CancellationToken cancellationToken) 
        => await Handler(command, _commandHandler, cancellationToken);
}
