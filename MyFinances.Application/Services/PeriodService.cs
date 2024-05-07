using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyFinances.Application.Resources;
using MyFinances.Domain.DTO.Period;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Repositories;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;
using Serilog;

namespace MyFinances.Application.Services
{
    public class PeriodService(
        IPeriodValidator periodValidator,
        ILogger logger,
        IMapper mapper,
        IUnitOfWork unitOfWork): IPeriodService
    {
        private readonly IPeriodValidator _periodValidator = periodValidator;
        private readonly ILogger _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<BaseResult<PeriodDto>> CreateNewPeriod(int userId)
        {
            var isUserExist = _unitOfWork.Users.GetAll().Any(x => x.Id == userId);

            if (!isUserExist)
                return new BaseResult<PeriodDto>
                {
                    Failure = Error.NotFound("User.NotFound", ErrorMessages.User_NotFound)
                };

            var period = new Period()
            {
                Month = DateTime.UtcNow.Month,
                Year = DateTime.Now.Year,
                UserId = userId
            };

            await _unitOfWork.Periods.CreateAsync(period);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<PeriodDto>
            {
                Data = _mapper.Map<PeriodDto>(period)
            };
        }

        public async Task<BaseResult<PeriodDto>> CurrentPeriodByUserId(int userId)
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            var currentPeriod = await _unitOfWork.Periods
                .GetAll()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Year == currentYear && x.Month == currentMonth);

            var resultValidation = _periodValidator.ValidateOnNull(currentPeriod);

            if (!resultValidation.IsSuccess)
                return new BaseResult<PeriodDto>
                {
                    Failure = resultValidation.Failure
                };

            return new BaseResult<PeriodDto>
            {
                Data = _mapper.Map<PeriodDto>(currentPeriod)
            };
        }

        public async Task<BaseResult<PeriodDto>> DeletePeriod(int periodId)
        {
            var period = await _unitOfWork.Periods
                .GetAll()
                .FirstOrDefaultAsync(x => x.Id == periodId);

            var resultValidation = _periodValidator.ValidateOnNull(period);

            if (!resultValidation.IsSuccess)
                return new BaseResult<PeriodDto>()
                {
                    Failure = resultValidation.Failure
                };

            _unitOfWork.Periods.Delete(period);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<PeriodDto>
            {
                Data = _mapper.Map<PeriodDto>(period)
            };
        }

        public async Task<BaseResult<PeriodDto>> GetByYearAndMonth(int userId, int year, int month)
        {
            var period = await _unitOfWork.Periods
                .GetAll()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Year == year && x.Month == month);

            var resultValidation = _periodValidator.ValidateOnNull(period);

            if (!resultValidation.IsSuccess)
                return new BaseResult<PeriodDto>()
                {
                    Failure = resultValidation.Failure
                };

            return new BaseResult<PeriodDto>
            {
                Data = _mapper.Map<PeriodDto>(period)
            };
        }

        public async Task<CollectionResult<PeriodDto>> PeriodsPaging(int userId, int currentPage, int step, string order)
        {
            var periodsAmount = await _unitOfWork.Periods.GetAll().CountAsync(x => x.UserId == userId);

            var resultValidation = _periodValidator.PeriodsPagingValidator(currentPage, step, order, periodsAmount);

            if (!resultValidation.IsSuccess)
                return new CollectionResult<PeriodDto>
                {
                    Failure = resultValidation.Failure
                };

            int alreadyLoaded = (currentPage - 1) * step;

            IQueryable<Period> allUserPeriods = _unitOfWork.Periods.GetAll();

            if (order.Equals("desc"))
                allUserPeriods = allUserPeriods.OrderDescending();

            var pagedPeriodDtos = allUserPeriods
                    .Skip(alreadyLoaded)
                    .Take(step)
                    .Select(period => _mapper.Map<PeriodDto>(period));

            return new CollectionResult<PeriodDto>()
            {
                Data = pagedPeriodDtos
            };
        }

        public async Task<BaseResult<double>> ProfitOfPeriod(int periodId)
        {
            var isPeriodExist = _unitOfWork.Periods.GetAll().Any(x => x.Id == periodId);

            if (!isPeriodExist)
                return new BaseResult<double>()
                {
                    Failure = Error.NotFound("Period.NotFound", ErrorMessages.Period_NotFound)
                };

            var operations = _unitOfWork.Operations.GetAll().Where(x => x.PeriodId == periodId);

            double sum = 0;

            foreach (var operation in operations)
                sum += operation.Amount;

            return new BaseResult<double>
            {
                Data = sum
            };
        }
    }
}
