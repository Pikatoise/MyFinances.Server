using AutoMapper;
using FluentValidation;
using MyFinances.Application.Resources;
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

        public async Task<BaseResult<OperationDto>> DeleteOperationById(int operationId)
        {
            var operation = _unitOfWork.Operations.GetAll().FirstOrDefault(x => x.Id == operationId);

            var resultValidation = _operationValidator.ValidateOnNull(operation);

            if (!resultValidation.IsSuccess)
                return new BaseResult<OperationDto>()
                {
                    Failure = resultValidation.Failure
                };

            _unitOfWork.Operations.Delete(operation);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<OperationDto>()
            {
                Data = _mapper.Map<OperationDto>(operation)
            };
        }

        public async Task<CollectionResult<OperationDto>> FilterOperationsByProfit(IEnumerable<OperationDto> operations, bool isProfit)
        {
            var filteredOperations = operations.Where(x => x.Amount > 0 == isProfit);

            return new CollectionResult<OperationDto>()
            {
                Count = filteredOperations.Count(),
                Data = filteredOperations
            };
        }

        public async Task<CollectionResult<OperationDto>> FilterOperationsByType(IEnumerable<OperationDto> operations, int typeId)
        {
            var filteredOperations = operations.Where(x => x.TypeId == typeId);

            return new CollectionResult<OperationDto>()
            {
                Count = filteredOperations.Count(),
                Data = filteredOperations
            };
        }

        public async Task<CollectionResult<OperationDto>> GetOperationsByPeriod(int periodId, int? typeId, bool? isProfit)
        {
            var isPeriodExist = _unitOfWork.Periods.GetAll().Any(x => x.Id == periodId);

            if (!isPeriodExist)
                return new CollectionResult<OperationDto>()
                {
                    Failure = Error.NotFound("Period.NotFound", ErrorMessages.Period_NotFound)
                };

            var operationDtos = _unitOfWork.Operations
                .GetAll()
                .Where(x => x.PeriodId == periodId).Select(x => _mapper.Map<OperationDto>(x));

            var result = new CollectionResult<OperationDto>()
            {
                Count = operationDtos.Count(),
                Data = operationDtos
            };

            if (result.IsSuccess && typeId != null)
                result = await FilterOperationsByType(result.Data, (int)typeId);

            if (result.IsSuccess && isProfit != null)
                result = await FilterOperationsByProfit(result.Data, (bool)isProfit);

            return result;
        }

        public async Task<CollectionResult<int>> GroupByTypeAndSum(int periodId)
        {
            var isPeriodExist = _unitOfWork.Periods.GetAll().Any(x => x.Id == periodId);

            if (!isPeriodExist)
                return new CollectionResult<int>()
                {
                    Failure = Error.NotFound("Period.NotFound", ErrorMessages.Period_NotFound)
                };

            var operations = _unitOfWork.Operations.GetAll().Where(x => x.PeriodId == periodId);

            if (operations.Count() == 0)
                return new CollectionResult<int>()
                {
                    Data = new List<int>() { 0 }
                };

            Dictionary<int, int> typeSumPairs = new Dictionary<int, int>();

            foreach (var operation in operations)
            {
                if (typeSumPairs.ContainsKey(operation.TypeId))
                    typeSumPairs[operation.TypeId] += (int)operation.Amount;
                else
                    typeSumPairs.Add(operation.TypeId, (int)operation.Amount);
            }

            return new CollectionResult<int>()
            {
                Count = typeSumPairs.Count,
                Data = typeSumPairs.Select(x => x.Value)
            };
        }

        public async Task<BaseResult<OperationDto>> UpdateOperation(UpdateOperationDto dto)
        {
            var resultDtoValidation = _updateDtoValidator.Validate(dto);

            if (!resultDtoValidation.IsValid)
            {
                var error = resultDtoValidation.Errors.FirstOrDefault();

                return new BaseResult<OperationDto>()
                {
                    Failure = error == null ? Error.None : Error.Validation(error.ErrorCode, error.ErrorMessage)
                };
            }

            var operation = _unitOfWork.Operations.GetAll().FirstOrDefault(x => x.Id == dto.OperationId);
            var type = _unitOfWork.OperationTypes.GetAll().FirstOrDefault(x => x.Id == dto.TypeId);

            var resultValidation = _operationValidator.UpdateValidator(operation, type);

            if (!resultValidation.IsSuccess)
                return new BaseResult<OperationDto>()
                {
                    Failure = resultValidation.Failure
                };

            operation.Title = dto.Title;
            operation.Amount = dto.Amount;
            operation.TypeId = dto.TypeId;

            _unitOfWork.Operations.Update(operation);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<OperationDto>()
            {
                Data = _mapper.Map<OperationDto>(operation)
            };
        }
    }
}
