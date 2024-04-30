using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyFinances.Application.Mapping;
using MyFinances.Application.Services;
using MyFinances.Application.Validations.DtoValidations.Operation;
using MyFinances.Application.Validations.DtoValidations.Plan;
using MyFinances.Application.Validations.ServiceValidations;
using MyFinances.Domain.DTO.Operation;
using MyFinances.Domain.DTO.Plan;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Interfaces.Validations;

namespace MyFinances.Application.DI
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(CurrencyMapping),
                typeof(PlanMapping),
                typeof(PeriodMapping));

            InitServices(services);
        }

        private static void InitServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyValidator, CurrencyValidator>();
            services.AddScoped<IOperationTypeValidator, OperationTypeValidator>();
            services.AddScoped<IOperationValidator, OperationValidator>();
            services.AddScoped<IPeriodValidator, PeriodValidator>();
            services.AddScoped<IPlanValidator, PlanValidator>();

            services.AddScoped<IValidator<CreateOperationDto>, CreateOperationValidator>();
            services.AddScoped<IValidator<UpdateOperationDto>, UpdateOperationValidator>();
            services.AddScoped<IValidator<CreatePlanDto>, CreatePlanValidator>();
            services.AddScoped<IValidator<CreatePlanDto>, CreatePlanValidator>();

            services.AddScoped<IFixerService, FixerService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IPeriodService, PeriodService>();
            services.AddScoped<IPlanService, PlanService>();
        }
    }
}
