﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyFinances.Domain.DTO.Currency;
using MyFinances.Domain.Entity;
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

            var validationOnNull = _currencyValidator.ValidateOnNull(currency);
            var validationOnExpired = _currencyValidator.ValidateOnExpired(currency);

            if (!(validationOnNull.IsSuccess && validationOnExpired.IsSuccess))
            {
                var updateResult = await UpdateCurrencies();

                if (!updateResult.IsSuccess)
                    return new BaseResult<CurrencyDto>
                    {
                        Failure = updateResult.Failure,
                    };

                currency = await _unitOfWork.Currencies.GetAll().FirstOrDefaultAsync(x => x.Name.Equals(currencyName));

                validationOnNull = _currencyValidator.ValidateOnNull(currency);

                if (!validationOnNull.IsSuccess)
                    return new BaseResult<CurrencyDto>
                    {
                        Failure = validationOnNull.Failure
                    };
            }

            return new BaseResult<CurrencyDto>
            {
                Data = _mapper.Map<CurrencyDto>(currency)
            };
        }

        public async Task<BaseResult> UpdateCurrencies()
        {
            var result = await _fixerService.GetCurrencies();

            if (!result.IsSuccess)
                return new BaseResult()
                {
                    Failure = result.Failure
                };

            var isCurrencyInDb = _unitOfWork.Currencies.GetAll().Count() > 0;

            foreach (Currency freshCurrency in result.Data)
            {
                if (isCurrencyInDb)
                    _unitOfWork.Currencies.Update(freshCurrency);
                else
                    await _unitOfWork.Currencies.CreateAsync(freshCurrency);
            }

            return new BaseResult();
        }
    }
}
