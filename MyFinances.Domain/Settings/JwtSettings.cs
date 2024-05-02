namespace MyFinances.Domain.Settings
{
    public class JwtSettings
    {
        public const string DefaultSection = "Jwt";

        public required string Issuer { get; set; }

        public required string Audience { get; set; }

        public required string Authority { get; set; }

        public required string JwtKey { get; set; }

        public int Lifetime { get; set; }

        public int RefreshTokenValidityInDays { get; set; }
    }
}
