using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyFinances.Domain.DTO;
using MyFinances.Domain.Interfaces.Repositories;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;
using MyFinances.Domain.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MyFinances.Application.Services
{
    public class TokenService(
        IOptions<JwtSettings> options,
        IUnitOfWork unitOfWork,
        ITokenValidator tokenValidator): ITokenService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ITokenValidator _tokenValidator = tokenValidator;
        private readonly string _jwtKey = options.Value.JwtKey;
        private readonly string _issuer = options.Value.Issuer;
        private readonly string _audience = options.Value.Audience;
        private readonly int _accessTokenLifeTime = options.Value.Lifetime;
        private readonly int _refreshTokenValidityInDays = options.Value.RefreshTokenValidityInDays;

        public async Task<BaseResult<TokenDto>> RefreshToken(TokenDto dto)
        {
            var accessToken = dto.AccessToken;
            var refreshToken = dto.RefreshToken;

            var resultValidationTokensExists = _tokenValidator.ValidateTokensExists(refreshToken, accessToken);

            if (!resultValidationTokensExists.IsSuccess)
                return new BaseResult<TokenDto>()
                {
                    Failure = resultValidationTokensExists.Failure
                };

            var claimPrincipal = GetPrincipalFromExpiredToken(accessToken);

            var userName = claimPrincipal.Identity?.Name;

            var user = await _unitOfWork.Users.GetAll()
                .Include(x => x.UserToken)
                .FirstOrDefaultAsync(x => x.Login.Equals(userName));

            var resultValidationRefreshTokenAuthentic = _tokenValidator.ValidateRefreshTokenAuthentic(user, refreshToken);

            if (!resultValidationRefreshTokenAuthentic.IsSuccess)
                return new BaseResult<TokenDto>()
                {
                    Failure = resultValidationRefreshTokenAuthentic.Failure
                };

            var newAccessToken = GenerateAccessToken(claimPrincipal.Claims);

            var newRefreshToken = GenerateRefreshToken();

            user.UserToken.RefreshToken = newRefreshToken;
            user.UserToken.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_refreshTokenValidityInDays);

            _unitOfWork.Users.Update(user);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<TokenDto>()
            {
                Data = new TokenDto()
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken,
                }
            };
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(_issuer, _audience, claims, null, DateTime.UtcNow.AddMinutes(_accessTokenLifeTime), credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }

        public string GenerateRefreshToken()
        {
            var randomNumbers = new byte[32];

            using var randomNumberGenerator = RandomNumberGenerator.Create();

            randomNumberGenerator.GetBytes(randomNumbers);

            return Convert.ToBase64String(randomNumbers);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken)
        {
            var tokenValidationParams = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey)),
                ValidateLifetime = false,
                ValidAudience = _audience,
                ValidIssuer = _issuer
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var claimsPrinciple = tokenHandler.ValidateToken(accessToken, tokenValidationParams, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return claimsPrinciple;
        }
    }
}
