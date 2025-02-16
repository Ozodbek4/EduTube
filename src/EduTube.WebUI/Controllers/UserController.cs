using AutoMapper;
using EduTube.Application.Common.DTOs;
using EduTube.Application.Features.Users.Commands;
using EduTube.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduTube.WebUI.Controllers;

//[CustomAuthorize(nameof(UserRole.Client))]
public class UserController(IMediator mediator) : BaseController
{
    [HttpGet("{id:long}")]
    public async ValueTask<IActionResult> GetById([FromRoute] long id)
    {
        var userDto = await mediator.Send(new GetUserByIdQuery(id));

        return Ok(userDto);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        var userDto = await mediator.Send(command);

        return Ok(userDto);
    }

    [HttpPut("{id:long}")]
    public async ValueTask<IActionResult> Put([FromRoute] long id, [FromBody] UpdateUserCommand command)
    {
        command.Id = id;
        var userDto = await mediator.Send(command);

        return Ok(userDto);
    }

    [HttpDelete("{id:long}")]
    public async ValueTask<IActionResult> Delete([FromRoute] long id)
    {
        var result = await mediator.Send(new DeleteUserCommand(id));

        return Ok(result);
    }
}