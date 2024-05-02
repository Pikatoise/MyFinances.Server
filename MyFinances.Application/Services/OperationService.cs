using AutoMapper;
using FluentValidation;
using MyFinances.Domain.DTO.Operation;
using MyFinances.Domain.Entity;
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
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger _logger = logger;
        private readonly IOperationValidator _operationValidator = operationValidator;
        private readonly IValidator<CreateOperationDto> _createDtoValidator = createDtoValidator;
        private readonly IValidator<UpdateOperationDto> _updateDtoValidator = updateDtoValidator;

        public async Task<BaseResult<OperationDto>> CreateOperation(CreateOperationDto dto)
        {
            var resultDtoValidation = _createDtoValidator.Validate(dto);

            if (!resultDtoValidation.IsValid)
            {
                var error = resultDtoValidation.Errors.FirstOrDefault();

                return new BaseResult<OperationDto>()
                {
                    Failure = error == null ? Error.None : Error.Validation(error.ErrorCode, error.ErrorMessage)
                };
            }

            var period = _unitOfWork.Periods.GetAll().FirstOrDefault(x => x.Id == dto.PeriodId);
            var type = _unitOfWork.OperationTypes.GetAll().FirstOrDefault(x => x.Id == dto.TypeId);

            var resultValidation = _operationValidator.CreateValidator(period, type);

            if (!resultValidation.IsSuccess)
                return new BaseResult<OperationDto>()
                {
                    Failure = resultValidation.Failure
                };

            var operation = new Operation()
            {
                Title = dto.Title,
                Amount = dto.Amount,
                PeriodId = dto.PeriodId,
                TypeId = dto.TypeId
            };

            await _unitOfWork.Operations.CreateAsync(operation);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<OperationDto>()
            {
                Data = _mapper.Map<OperationDto>(operation)
            };
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
