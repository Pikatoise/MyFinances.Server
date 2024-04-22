using AutoMapper;
using MyFinances.Domain.DTO.Plan;
using MyFinances.Domain.Entity;

namespace MyFinances.Application.Mapping
{
    public class PlanMapping: Profile
    {
        public PlanMapping()
        {
            CreateMap<Plan, PlanDto>()
                .ForCtorParam("FinalDate", o => o.MapFrom(k => k.FinalDate.ToLongDateString()))
                .ReverseMap()
                .ForMember(dest => dest.FinalDate, opt => opt.MapFrom(src => DateTime.Parse(src.FinalDate)));
        }
    }
}
