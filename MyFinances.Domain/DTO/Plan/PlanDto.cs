namespace MyFinances.Domain.DTO.Plan
{
    public record PlanDto(int Id, string Name, double Amount, string FinalDate, int Status, string TypeIconSrc);
}
