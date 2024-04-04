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

        /// <summary>
        /// Delete user plan
        /// </summary>
        /// <param name="planId">Plan identificator</param>
        /// <returns><c>PlanDto</c>: deleted plan if success
        /// <para><c>null</c>: null otherwise</para></returns>
        Task<BaseResult<PlanDto?>> DeletePlan(int planId);

        /// <summary>
        /// Change plan state to opposite
        /// </summary>
        /// <param name="planId">Plan identificator</param>
        /// <returns><c>bool</c>: current plan state</returns>
        Task<BaseResult<int>> ChangePlanStatus(int planId);

        /// <summary>
        /// Add plan
        /// </summary>
        /// <param name="dto">Data for new plan</param>
        /// <returns><c>PlanDto</c>: created plan if success
        /// <para><c>null</c>: otherwise</para></returns>
        Task<BaseResult<PlanDto?>> CreatePlan(CreatePlanDto dto);

        /// <summary>
        /// Update plan
        /// </summary>
        /// <param name="dto">Data for plan update</param>
        /// <returns><c>PlanDto</c>: updated plan if success
        /// <para><c>null</c>: otherwise</para></returns>
        Task<BaseResult<PlanDto?>> UpdatePlan(UpdatePlanDto dto);
    }
}
