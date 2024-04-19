using MyFinances.Domain.DTO.Fixer;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Enum;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Result;
using System.Net.Http.Json;

namespace MyFinances.Application.Services
{
    public class FixerService(HttpClient httpClient): IFixerService
    {
        public async Task<CollectionResult<Currency>> GetCurrencies()
        {
            var requestParams = httpClient.DefaultRequestHeaders.ToDictionary();

            string accessKey = requestParams["access_key"].First();
            string symbols = requestParams["symbols"].First();
            string format = requestParams["format"].First();

            var response = await httpClient.GetFromJsonAsync<RatesRequestDto>($"latest?access_key={accessKey}&symbols={symbols}&format={format}");

            List<Currency> currencies = new List<Currency>()
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

            return new CollectionResult<Currency>
            {
                Count = currencies.Count,
                Data = currencies
            };
        }
    }
}
