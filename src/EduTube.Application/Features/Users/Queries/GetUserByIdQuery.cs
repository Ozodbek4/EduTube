using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Common.DTOs;

namespace EduTube.Application.Features.Users.Queries;

public record GetUserByIdQuery(long Id) : IQuery<UserDto>;