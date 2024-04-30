using AutoMapper;
using FluentValidation;
using MyFinances.Domain.DTO.Operation;
using MyFinances.Domain.Interfaces.Repositories;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;
using Serilog;

namespace MyFinances.Application.Services
{
    public class OperationService(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ILogger logger,
        IOperationValidator operationValidator,
        IValidator<CreateOperationDto> createDtoValidator,
        IValidator<UpdateOperationDto> updateDtoValidator): IOperationService
    {
        public Task<BaseResult<OperationDto>> CreateOperation(CreateOperationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<OperationDto>> DeleteOperationById(int operationId)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionResult<OperationDto>> FilterOperationsByProfit(IEnumerable<OperationDto> operations, bool isProfit)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionResult<OperationDto>> FilterOperationsByType(IEnumerable<OperationDto> operations, int typeFilterId)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionResult<OperationDto>> GetOperationsByPeriod(int periodId)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionResult<int>> GroupByTypeAndSum(int periodId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<OperationDto>> UpdateOperation(UpdateOperationDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
