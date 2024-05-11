using Microsoft.Extensions.Options;
using MyFinances.Domain.DTO.Fixer;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Enum;
using MyFinances.Domain.Errors;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Result;
using MyFinances.Domain.Settings;
using System.Net.Http.Json;

namespace MyFinances.Application.Services
{
    public class FixerService(IOptions<FixerSettings> apiOptions): IFixerService
    {
        private readonly FixerSettings _apiOptions = apiOptions.Value;

        public async Task<CollectionResult<Currency>> GetCurrencies()
        {
            HttpClient fixerClient = new HttpClient()
            {
                BaseAddress = new Uri(_apiOptions.BaseAddress)
            };

            var response = await fixerClient
                .GetFromJsonAsync<RatesRequestDto>($"latest?access_key={_apiOptions.AccessKey}&symbols={_apiOptions.Symbols}&format={_apiOptions.Format}");

            CollectionResult<Currency> result = new CollectionResult<Currency>();

            if (response != null && response.success)
            {
                result.Data = new List<Currency>()
                {
                    new Currency()
                    {
                        Name = nameof(Currencies.EUR),
                        Value = Math.Round(response.rates[nameof(Currencies.RUB)] * 100) / 100
                    },
                    new Currency()
                    {
                        Name = nameof(Currencies.USD),
                        Value = Math.Round(response.rates[nameof(Currencies.RUB)] / response.rates[nameof(Currencies.USD)] * 100) / 100
                    }
                };
            }
            else
                result.Failure = FixerErrors.FixerBadRequest;

            return result;
        }
    }
}
