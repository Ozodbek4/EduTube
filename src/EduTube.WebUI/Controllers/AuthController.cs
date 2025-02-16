using EduTube.Application.Features.Login.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduTube.WebUI.Controllers;

public class AuthController(IMediator mediator) : BaseController
{
    [HttpPost("login")]
    public async ValueTask<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await mediator.Send(command);

        return Ok(result);
    }
}