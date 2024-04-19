using MyFinances.Domain.DTO.Fixer;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Result;
using System.Net.Http.Json;

namespace MyFinances.Application.Services
{
    public class FixerService(HttpClient httpClient): IFixerService
    {
        public async Task<CollectionResult<Currency>> GetCurrencies()
        {
            var response = await httpClient.GetFromJsonAsync<RatesRequestDto>("latest?");

            return null;
        }
    }
}
