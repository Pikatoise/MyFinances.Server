using AutoMapper;
using MyFinances.Domain.DTO.User;
using MyFinances.Domain.Entity;

namespace MyFinances.Application.Mapping
{
    public class UserMapping: Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();
        }
    }
}
