using Application;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace RdiTest.Api.Controllers;

public class BasicController : ControllerBase
{
    protected async Task<IActionResult> 
        Handler<T, U>(T command, ICommandHandler<T, U> handler, CancellationToken cancellationToken) 
        where U : Task<Result>
    {
        var result = await handler.Handle(command, cancellationToken);
        
        if (result.IsSuccess)
            return Ok();
        
        return StatusCode(500);
    }
}