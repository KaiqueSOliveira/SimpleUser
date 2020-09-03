using AutoMapper;
using SimpleUser.Dtos;
using SimpleUser.Models;

namespace SimpleUser.Profiles
{
    public class SimpleUserProfile : Profile
    {
        public SimpleUserProfile()
        {
            // Source -> Target
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto , User>();
            CreateMap<UserUpdateDto , User>();
            CreateMap<User , UserUpdateDto>();
        }
    }
}