using Application;
using Application.Command;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace RdiTest.Api.Controllers;

/*
 * Could have have used MediatR here but decided against because there is only one endpoint 
 */

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
    public async Task<IActionResult> PostOrder([FromBody] OrderCommand command, CancellationToken cancellationToken) 
        => await Handler(command, _commandHandler, cancellationToken);
}
