using MyFinances.Application.Resources;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class PlanValidator: IPlanValidator
    {
        public BaseResult ValidateOnNull(Plan? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("Plan.NotFound", ErrorMessages.Plan_NotFound)
                };

            return new BaseResult();
        }
    }
}
