using AutoMapper;
using MyFinances.Domain.DTO.Operation;
using MyFinances.Domain.Entity;

namespace MyFinances.Application.Mapping
{
    public class OperationMapping: Profile
    {
        public OperationMapping()
        {
            CreateMap<Operation, OperationDto>()
                .ForCtorParam("CreatedAt", o => o.MapFrom(k => k.CreatedAt.ToLongDateString()))
                .ReverseMap()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Parse(src.CreatedAt)));
        }
    }
}
