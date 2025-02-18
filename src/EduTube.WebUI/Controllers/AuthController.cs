using EduTube.Application.Features.Login.Commands;
using EduTube.Domain.Enums;
using EduTube.WebUI.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduTube.WebUI.Controllers;

[CustomAuthorize(nameof(UserRole.Client))]
public class AuthController(IMediator mediator) : BaseController
{
    [AllowAnonymous]
    [HttpPost("login")]
    public async ValueTask<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("password")]
    public async ValueTask<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPut("username")]
    public async ValueTask<IActionResult> UpdateUserName([FromBody] UpdateUserNameCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [CustomAuthorize(nameof(UserRole.Admin))]
    [HttpPut("admin/password")]
    public async ValueTask<IActionResult> UpdatePasswordByAdmin([FromBody] UpdatePasswordByAdminCommand command)
    {
        return Ok(await mediator.Send(command));
    }
}