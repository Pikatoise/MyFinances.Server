using System.ComponentModel.DataAnnotations;

namespace MyFinances.Domain.Settings
{
    public class FixerSettings
    {
        public const string ConfigurationSection = "Fixer";

        [Required, Url]
        public string BaseAddress { get; init; } = string.Empty;

        [Required]
        public string AccessKey { get; init; } = string.Empty;

        [Required]
        public string Symbols { get; init; } = string.Empty;

        [Required]
        public string Format { get; init; } = string.Empty;
    }
}
