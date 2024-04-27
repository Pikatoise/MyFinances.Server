using AutoMapper;
using FluentValidation;
using MyFinances.Application.Resources;
using MyFinances.Domain.DTO.Plan;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Enum;
using MyFinances.Domain.Interfaces.Repositories;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;
using Serilog;

namespace MyFinances.Application.Services
{
    public class PlanService(
        IPlanValidator planValidator,
        ILogger logger,
        IMapper mapper,
        IValidator<CreatePlanDto> createDtoValidator,
        IValidator<UpdatePlanDto> updateDtoValidator,
        IUnitOfWork unitOfWork): IPlanService
    {
        private readonly IPlanValidator _planValidator = planValidator;
        private readonly ILogger _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<CreatePlanDto> _createDtoValidator = createDtoValidator;
        private readonly IValidator<UpdatePlanDto> _updateDtoValidator = updateDtoValidator;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResult<PlanDto>> CreatePlan(CreatePlanDto dto)
        {
            var resultDtoValidation = _createDtoValidator.Validate(dto);

            if (!resultDtoValidation.IsValid)
            {
                var errorValidation = resultDtoValidation.Errors.FirstOrDefault();

                if (errorValidation == null)
                    return new BaseResult<PlanDto>()
                    {
                        Failure = Error.None
                    };

                return new BaseResult<PlanDto>()
                {
                    Failure = Error.Validation(errorValidation.ErrorCode, errorValidation.ErrorMessage)
                };
            }

            var user = _unitOfWork.Users.GetAll().FirstOrDefault(x => x.Id == dto.UserId);
            var type = _unitOfWork.OperationTypes.GetAll().FirstOrDefault(x => x.Id == dto.TypeId);

            var resultValidation = _planValidator.ValidateOnUserAndTypeExist(user, type);

            if (!resultValidation.IsSuccess)
                return new BaseResult<PlanDto>()
                {
                    Failure = resultValidation.Failure
                };

            var newPlan = new Plan()
            {
                Name = dto.Name,
                Amount = dto.Amount,
                FinalDate = DateTime.Parse(dto.FinalDate),
                Status = (int)PlanStatuses.InProgress,
                Type = type,
                User = user
            };

            await _unitOfWork.Plans.CreateAsync(newPlan);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<PlanDto>()
            {
                Data = _mapper.Map<PlanDto>(newPlan)
            };
        }

        public async Task<BaseResult<int>> ChangePlanStatus(int planId, int status)
        {
            var plan = _unitOfWork.Plans.GetAll().FirstOrDefault(x => x.Id == planId);

            var resultValidation = _planValidator.ValidateOnNull(plan);

            if (!resultValidation.IsSuccess)
                return new BaseResult<int>()
                {
                    Failure = resultValidation.Failure
                };

            if (plan.Status != status)
            {
                plan.Status = status;

                _unitOfWork.Plans.Update(plan);

                await _unitOfWork.SaveChangesAsync();
            }

            return new BaseResult<int>()
            {
                Data = plan.Status
            };
        }

        public async Task<BaseResult<PlanDto>> DeletePlan(int planId)
        {
            var plan = _unitOfWork.Plans.GetAll().FirstOrDefault(x => x.Id == planId);

            var resultValidation = _planValidator.ValidateOnNull(plan);

            if (!resultValidation.IsSuccess)
                return new BaseResult<PlanDto>()
                {
                    Failure = resultValidation.Failure
                };

            _unitOfWork.Plans.Delete(plan);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<PlanDto>()
            {
                Data = _mapper.Map<PlanDto>(plan)
            };
        }

        public async Task<CollectionResult<PlanDto>> GetPlansByUserId(int userId)
        {
            var isUserExist = _unitOfWork.Users.GetAll().Any(x => x.Id == userId);

            if (!isUserExist)
                return new CollectionResult<PlanDto>()
                {
                    Failure = Error.NotFound("User.NotFound", ErrorMessages.User_NotFound)
                };

            var planDtos = _unitOfWork.Plans
                .GetAll()
                .Where(x => x.UserId == userId)
                .Select(plan => _mapper.Map<PlanDto>(plan));

            return new CollectionResult<PlanDto>()
            {
                Count = planDtos.Count(),
                Data = planDtos
            };
        }

        public async Task<BaseResult<PlanDto>> UpdatePlan(UpdatePlanDto dto)
        {
            var resultDtoValidation = _updateDtoValidator.Validate(dto);

            if (!resultDtoValidation.IsValid)
            {
                var errorValidation = resultDtoValidation.Errors.FirstOrDefault();

                if (errorValidation == null)
                    return new BaseResult<PlanDto>()
                    {
                        Failure = Error.None
                    };

                return new BaseResult<PlanDto>()
                {
                    Failure = Error.Validation(errorValidation.ErrorCode, errorValidation.ErrorMessage)
                };
            }

            var plan = _unitOfWork.Plans.GetAll().FirstOrDefault(x => x.Id == dto.PlanId);

            var resultValidation = _planValidator.ValidateOnNull(plan);

            if (!resultValidation.IsSuccess)
                return new BaseResult<PlanDto>()
                {
                    Failure = resultValidation.Failure
                };

            plan.Name = dto.Name;
            plan.Amount = dto.Amount;
            plan.TypeId = dto.TypeId;

            _unitOfWork.Plans.Update(plan);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<PlanDto>
            {
                Data = _mapper.Map<PlanDto>(plan)
            };
        }
    }
}
