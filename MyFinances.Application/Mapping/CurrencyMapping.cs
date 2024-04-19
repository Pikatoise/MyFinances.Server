using AutoMapper;
using MyFinances.Domain.DTO.Currency;
using MyFinances.Domain.Entity;

namespace MyFinances.Application.Mapping
{
    public class CurrencyMapping: Profile
    {
        public CurrencyMapping()
        {
            CreateMap<Currency, CurrencyDto>()
                .ReverseMap();
        }
    }
}
