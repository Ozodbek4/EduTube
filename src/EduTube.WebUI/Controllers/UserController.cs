﻿using AutoMapper;
using EduTube.Application.Common.DTOs;
using EduTube.Application.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduTube.WebUI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async ValueTask<IActionResult> Post([FromBody] CreateUserDto createUserDto)
    {
        var command = new CreateUserCommand(createUserDto);

        var userDto = mapper.Map<UserDto>(createUserDto);
        userDto.Id = await mediator.Send(command);

        return Ok(userDto);
    }
}