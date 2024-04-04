using MyFinances.Domain.DTO.Plan;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Services
{
    /// <summary>
    /// Service responsible for user plans controle
    /// </summary>
    public interface IPlanService
    {

        /// <summary>
        /// Get all user plans
        /// </summary>
        /// <param name="userId">User identificator</param>
        /// <returns><c>IEnumerable of PlanDto</c>: user plans</returns>
        Task<CollectionResult<PlanDto>> GetPlansByUserId(int userId);
    }
}
