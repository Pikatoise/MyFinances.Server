using System.ComponentModel.DataAnnotations;

namespace MyFinances.Domain.Settings
{
    public class FixerSettings
    {
        public const string ConfigurationSection = "Fixer";

        [Required, Url]
        public string BaseAddress { get; init; } = string.Empty;

        public string AccessToken { get; init; } = string.Empty;
    }
}
