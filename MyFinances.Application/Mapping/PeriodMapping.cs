using AutoMapper;
using MyFinances.Domain.DTO.Period;
using MyFinances.Domain.Entity;

namespace MyFinances.Application.Mapping
{
    public class PeriodMapping: Profile
    {
        public PeriodMapping()
        {
            CreateMap<Period, PeriodDto>()
                .ReverseMap();
        }
    }
}
