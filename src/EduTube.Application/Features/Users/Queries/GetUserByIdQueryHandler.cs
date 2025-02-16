using AutoMapper;
using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Common.DTOs;
using EduTube.Application.Common.Exceptions;
using EduTube.Domain.Entities;

namespace EduTube.Application.Features.Users.Queries;

public class GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper) : IQueryHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var exists = await userRepository.GetAsync(entity => entity.Id == request.Id && !entity.IsDeleted)
            ?? throw new NotFoundException(nameof(User), request.Id);

        return mapper.Map<UserDto>(exists);
    }
}