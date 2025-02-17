using AutoMapper;
using EduTube.Application.Common.DTOs;
using EduTube.Application.Common.Models;
using EduTube.Application.Features.Users.Commands;
using EduTube.Domain.Entities;

namespace EduTube.Application.Common.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();

        CreateMap<CreateUserCommand, User>();

        CreateMap<CreateUserCommand, UserDto>();

        CreateMap<PaginationResult<User>, PaginationResult<UserDto>>()
            .ConstructUsing((src, context) => new PaginationResult<UserDto>
            {
                Data = context.Mapper.Map<IEnumerable<UserDto>>(src.Data),
            });
    }
}