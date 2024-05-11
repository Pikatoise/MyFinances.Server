using MyFinances.Domain.Entity;
using MyFinances.Domain.Errors;
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
                    Failure = PlanErrors.PlanNotFound
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnUserAndTypeExist(User? user, OperationType? type)
        {
            if (user == null)
                return new BaseResult()
                {
                    Failure = UserErrors.UserNotFound
                };

            if (type == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("OperationType.NotFound", ErrorMessages.OperationType_NotFound)
                };

            return new BaseResult();
        }
    }
}
