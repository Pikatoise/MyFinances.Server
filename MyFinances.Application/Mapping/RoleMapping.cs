using AutoMapper;
using MyFinances.Domain.DTO.Role;
using MyFinances.Domain.Entity;

namespace MyFinances.Application.Mapping
{
    public class RoleMapping: Profile
    {
        public RoleMapping()
        {
            CreateMap<Role, RoleDto>()
                .ReverseMap();
        }
    }
}
