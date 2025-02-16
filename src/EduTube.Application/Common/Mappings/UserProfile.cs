using AutoMapper;
using EduTube.Application.Common.DTOs;
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
    }
}