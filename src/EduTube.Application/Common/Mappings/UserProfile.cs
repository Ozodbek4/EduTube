using AutoMapper;
using EduTube.Application.Common.DTOs.Users;
using EduTube.Domain.Entities;

namespace EduTube.Application.Common.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
        
        CreateMap<CreateUserDto, User>();

        CreateMap<CreateUserDto, UserDto>();
    }
}