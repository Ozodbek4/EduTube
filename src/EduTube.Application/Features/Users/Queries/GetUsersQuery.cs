using EduTube.Application.Abstractions.Messaging;
using EduTube.Application.Common.DTOs;
using EduTube.Application.Common.Models;

namespace EduTube.Application.Features.Users.Queries;

public record GetUsersQuery(PaginationParameters Pagination, SortingParameters? Sorting, string? Search = null) : IQuery<PaginationResult<UserDto>>;