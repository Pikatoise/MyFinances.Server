using AutoMapper;
using MyFinances.Domain.DTO.OperationType;
using MyFinances.Domain.Entity;

namespace MyFinances.Application.Mapping
{
    public class OperationTypeMapping: Profile
    {
        public OperationTypeMapping()
        {
            CreateMap<OperationType, OperationTypeDto>()
                .ReverseMap();
        }
    }
}
