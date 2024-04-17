using MyFinances.Domain.Entity;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Validations
{
    public interface IPeriodValidator: IBaseValidator<Period>
    {
        /// <summary>
        /// Check is out of range, is order correct
        /// </summary>
        /// <param name="currentPage">Current slice of periods</param>
        /// <param name="step">Amount of requested periods</param>
        /// <param name="order">Sorting order (only "asc" and "desc")</param>
        /// <param name="periodsAmount">Total amount of user periods</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult PeriodsPagingValidator(int currentPage, int step, string order, int periodsAmount);
    }
}
