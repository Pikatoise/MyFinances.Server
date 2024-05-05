using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyFinances.Application.Services;
using MyFinances.Application.Validations.DtoValidations.Operation;
using MyFinances.Application.Validations.DtoValidations.Plan;
using MyFinances.Application.Validations.DtoValidations.User;
using MyFinances.Application.Validations.DtoValidations.UserRole;
using MyFinances.Application.Validations.ServiceValidations;
using MyFinances.Domain.DTO.Operation;
using MyFinances.Domain.DTO.Plan;
using MyFinances.Domain.DTO.User;
using MyFinances.Domain.DTO.UserRole;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Interfaces.Validations;
using System.Reflection;

namespace MyFinances.Application.DI
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            InitServices(services);
        }

        private static void InitServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyValidator, CurrencyValidator>();
            services.AddScoped<IOperationTypeValidator, OperationTypeValidator>();
            services.AddScoped<IOperationValidator, OperationValidator>();
            services.AddScoped<IPeriodValidator, PeriodValidator>();
            services.AddScoped<IPlanValidator, PlanValidator>();
            services.AddScoped<IAuthValidator, AuthValidator>();
            services.AddScoped<IRoleValidator, RoleValidator>();
            services.AddScoped<ITokenValidator, TokenValidator>();

            services.AddScoped<IValidator<CreateOperationDto>, CreateOperationValidator>();
            services.AddScoped<IValidator<UpdateOperationDto>, UpdateOperationValidator>();
            services.AddScoped<IValidator<CreatePlanDto>, CreatePlanValidator>();
            services.AddScoped<IValidator<UpdatePlanDto>, UpdatePlanValidator>();
            services.AddScoped<IValidator<LoginUserDto>, LoginUserValidator>();
            services.AddScoped<IValidator<RegisterUserDto>, RegisterUserValidator>();
            services.AddScoped<IValidator<AddUserRoleDto>, AddUserRoleValidator>();
            services.AddScoped<IValidator<RemoveUserRoleDto>, RemoveUserRoleValidator>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IFixerService, FixerService>();
            services.AddScoped<IOperationService, OperationService>();
            services.AddScoped<IOperationTypeService, OperationTypeService>();
            services.AddScoped<IPeriodService, PeriodService>();
            services.AddScoped<IPlanService, PlanService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
