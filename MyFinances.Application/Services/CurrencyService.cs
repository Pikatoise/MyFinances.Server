using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyFinances.Domain.DTO.Currency;
using MyFinances.Domain.Interfaces.Repositories;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;
using Serilog;

namespace MyFinances.Application.Services
{
    public class CurrencyService(
        ICurrencyValidator currencyValidator,
        ILogger logger,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IFixerService fixerService): ICurrencyService
    {
        private readonly ICurrencyValidator _currencyValidator = currencyValidator;
        private readonly ILogger _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IFixerService _fixerService = fixerService;

        public async Task<BaseResult<CurrencyDto>> GetCurrencyValue(string currencyName)
        {
            var currency = await _unitOfWork.Currencies.GetAll().FirstOrDefaultAsync(x => x.Name.Equals(currencyName));

            var validation = _currencyValidator.ValidateOnNull(currency);

            if (!validation.IsSuccess)
            {
                await UpdateCurrencies();

                return new BaseResult<CurrencyDto>()
                {
                    Failure = validation.Failure
                };
            }

            validation = _currencyValidator.ValidateOnExpired(currency);

            if (validation.IsSuccess)
            {
                await UpdateCurrencies();

                return new BaseResult<CurrencyDto>()
                {
                    Failure = validation.Failure
                };
            }

            return new BaseResult<CurrencyDto>
            {
                Data = _mapper.Map<CurrencyDto>(currency)
            };
        }

        public Task<BaseResult<bool>> UpdateCurrencies()
        {
            throw new NotImplementedException();
        }
    }
}
