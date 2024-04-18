using AutoMapper;
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
        IUnitOfWork unitOfWork): ICurrencyService
    {
        private readonly ICurrencyValidator _currencyValidator = currencyValidator;
        private readonly ILogger _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public Task<BaseResult<CurrencyDto>> GetCurrencyValue(string currencyName)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<bool>> UpdateCurrencies()
        {
            throw new NotImplementedException();
        }
    }
}
