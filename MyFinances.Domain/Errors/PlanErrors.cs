using MyFinances.Domain.Resources;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Errors
{
    public static class PlanErrors
    {
        public static readonly Error PlanNotFound = Error.NotFound("Plan.NotFound", ErrorMessages.Plan_NotFound);
    }
}
