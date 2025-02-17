using AutoMapper;
using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Common.DTOs;
using EduTube.Application.Common.Models;
using EduTube.Domain.Entities;

namespace EduTube.Application.Features.Users.Queries;

public class GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper) : IQueryHandler<GetUsersQuery, PaginationResult<UserDto>>
{
    public async Task<PaginationResult<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var exists = await userRepository.GetEnumerableAsync(pagination: request.Pagination,
            sorting: request.Sorting,
            search: request.Search,
            asNoTracking: true,
            cancellationToken: cancellationToken);

        return mapper.Map<PaginationResult<UserDto>>(exists);
    }
}