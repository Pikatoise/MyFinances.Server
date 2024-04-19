namespace MyFinances.Domain.DTO.Fixer
{
    public record RatesRequestDto(bool success, DateOnly date, Dictionary<string, double> rates);
}
