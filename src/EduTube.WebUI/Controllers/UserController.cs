using AutoMapper;
using EduTube.Application.Common.DTOs.Users;
using EduTube.Application.Common.Exceptions;
using EduTube.Application.Features.Users.Commands;
using EduTube.Domain.Enums;
using EduTube.WebUI.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduTube.WebUI.Controllers;

[CustomAuthorize(nameof(UserRole.Client))]
public class UserController(IMediator mediator, IMapper mapper) : BaseController
{
    [HttpPost]
    public async ValueTask<IActionResult> Post([FromBody] CreateUserDto createUserDto)
    {
        var command = new CreateUserCommand(createUserDto);

        var userDto = mapper.Map<UserDto>(createUserDto);
        userDto.Id = await mediator.Send(command);

        return Ok(userDto);
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Get()
    {
        throw new AlreadyExistException("User", "name");
    }
}