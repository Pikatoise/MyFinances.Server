using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Validations
{
    public interface IBaseValidator<in T> where T : class
    {
        BaseResult ValidateOnNull(T? model);
    }
}
