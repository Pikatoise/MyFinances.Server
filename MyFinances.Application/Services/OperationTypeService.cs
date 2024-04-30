using AutoMapper;
using MyFinances.Domain.DTO.OperationType;
using MyFinances.Domain.Interfaces.Repositories;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;
using Serilog;

namespace MyFinances.Application.Services
{
    public class OperationTypeService(
        ILogger logger,
        IUnitOfWork unitOfWork,
        IOperationTypeValidator operationTypeValidator,
        IMapper mapper): IOperationTypeService
    {
        private readonly ILogger _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IOperationTypeValidator _operationTypeValidator = operationTypeValidator;
        private readonly IMapper _mapper = mapper;

        public Task<BaseResult<OperationTypeDto>> AddTypeAssociation(int typeId, string association)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionResult<OperationTypeDto>> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public Task<CollectionResult<OperationTypeDto>> GetTypesByAssociation(string association)
        {
            throw new NotImplementedException();
        }
    }
}
