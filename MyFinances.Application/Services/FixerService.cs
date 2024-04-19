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
            string accessKey = httpClient.DefaultRequestHeaders.FirstOrDefault(x => x.Key == "access_key").Value.First();
            string symbols = httpClient.DefaultRequestHeaders.FirstOrDefault(x => x.Key == "symbols").Value.First();
            string format = httpClient.DefaultRequestHeaders.FirstOrDefault(x => x.Key == "format").Value.First();

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
