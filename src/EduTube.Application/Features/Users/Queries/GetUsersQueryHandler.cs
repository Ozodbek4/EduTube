using AutoMapper;
using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Abstractions.Persistence;
using EduTube.Application.Common.DTOs;
using EduTube.Application.Common.Extensions;
using EduTube.Application.Common.Models;

namespace EduTube.Application.Features.Users.Queries;

public class GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper) : IQueryHandler<GetUsersQuery, PaginationResult<UserDto>>
{
    public async Task<PaginationResult<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var exists = userRepository.GetQueryable();

        if (!string.IsNullOrEmpty(request.Search))
            exists = exists.Where(entity => entity.FirstName.ToLower().Contains(request.Search.ToLower())
                || entity.LastName.ToLower().Contains(request.Search.ToLower())
                || entity.UserName.ToLower().Contains(request.Search.ToLower()));

        exists = exists.Where(entity => !entity.IsDeleted);

        exists.SortBy(request.Sorting);

        return mapper.Map<PaginationResult<UserDto>>(exists.ToPaginate(request.Pagination));
    }
}