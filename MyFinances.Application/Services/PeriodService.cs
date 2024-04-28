using MyFinances.Domain.DTO.Period;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Services
{
    public class PeriodService: IPeriodService
    {
        public Task<BaseResult<PeriodDto>> CreateNewPeriod(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<PeriodDto?>> CurrentPeriodByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<PeriodDto?>> DeletePeriod(int periodId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<PeriodDto?>> GetByYearAndMonth(int userId, int year, int month)
        {
            throw new NotImplementedException();
        }

        public Task<CollectionResult<PeriodDto>> PeriodsPaging(int userId, int currentPage, int step, string order = "asc")
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<double>> ProfitOfPeriod(int periodId)
        {
            throw new NotImplementedException();
        }
    }
}
