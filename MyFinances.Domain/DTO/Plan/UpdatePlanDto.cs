namespace MyFinances.Domain.DTO.Plan
{
    public record UpdatePlanDto(int PlanId, string Name, double Amount, int TypeId);
}
