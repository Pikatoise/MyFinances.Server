using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyFinances.Domain.DTO;
using MyFinances.Domain.DTO.User;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Enum;
using MyFinances.Domain.Interfaces.Repositories;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;
using MyFinances.Domain.Settings;
using Serilog;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MyFinances.Application.Services
{
    public class AuthService(
        ILogger logger,
        IMapper mapper,
        ITokenService tokenService,
        IUnitOfWork unitOfWork,
        IAuthValidator authValidator,
        IOptions<JwtSettings> options,
        IRoleValidator roleValidator): IAuthService
    {
        private readonly ILogger _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly ITokenService _tokenService = tokenService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IAuthValidator _authValidator = authValidator;
        private readonly int _refreshTokenValidityInDays = options.Value.RefreshTokenValidityInDays;
        private readonly IRoleValidator _roleValidator = roleValidator;

        public async Task<BaseResult<TokenDto>> Login(LoginUserDto dto)
        {
            var user = await _unitOfWork.Users.GetAll()
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(u => u.Login.Equals(dto.Login));

            var resultValidationUserOnNull = _authValidator.ValidateOnNull(user);

            if (!resultValidationUserOnNull.IsSuccess)
                return new BaseResult<TokenDto>()
                {
                    Failure = resultValidationUserOnNull.Failure
                };

            var resultValidationPasswordVerifying = _authValidator.ValidatePasswordVerifying(IsVerifyPassword, user.Password, dto.Password);

            if (!resultValidationPasswordVerifying.IsSuccess)
                return new BaseResult<TokenDto>()
                {
                    Failure = resultValidationPasswordVerifying.Failure
                };

            var userToken = await _unitOfWork.UserTokens
                .GetAll()
                .FirstOrDefaultAsync(x => x.UserId == user.Id);

            var claims = user.Roles.Select(x => new Claim(ClaimTypes.Role, x.Name)).ToList();

            claims.Add(new Claim(ClaimTypes.Name, user.Login));

            var refreshToken = _tokenService.GenerateRefreshToken();
            var accesToken = _tokenService.GenerateAccessToken(claims);

            if (userToken == null)
            {
                userToken = new UserToken()
                {
                    UserId = user.Id,
                    RefreshToken = refreshToken,
                    RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_refreshTokenValidityInDays)
                };

                await _unitOfWork.UserTokens.CreateAsync(userToken);
            }
            else
            {
                userToken.RefreshToken = refreshToken;
                userToken.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_refreshTokenValidityInDays);

                _unitOfWork.UserTokens.Update(userToken);
            }

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<TokenDto>()
            {
                Data = new TokenDto()
                {
                    UserId = user.Id,
                    AccessToken = accesToken,
                    RefreshToken = refreshToken,
                }
            };
        }

        public async Task<BaseResult<UserDto>> Register(RegisterUserDto dto)
        {
            var resultValidationPasswords = _authValidator.ValidateNewUserPassword(dto.Password, dto.PasswordConfirm);

            if (!resultValidationPasswords.IsSuccess)
                return new BaseResult<UserDto>()
                {
                    Failure = resultValidationPasswords.Failure
                };

            var user = await _unitOfWork.Users.GetAll().FirstOrDefaultAsync(u => u.Login.Equals(dto.Login));

            var resultValidationUserOnNull = _authValidator.ValidateOnUserNotExist(user);

            if (!resultValidationUserOnNull.IsSuccess)
                return new BaseResult<UserDto>()
                {
                    Failure = resultValidationUserOnNull.Failure
                };

            var defaultRole = _unitOfWork.Roles.GetAll().FirstOrDefault(x => x.Name.Equals(nameof(Roles.User)));

            var resultValidationOnRoleExist = _roleValidator.ValidateOnNull(defaultRole);

            if (!resultValidationOnRoleExist.IsSuccess)
                return new BaseResult<UserDto>()
                {
                    Failure = resultValidationOnRoleExist.Failure
                };

            var hashedPassword = HashPassword(dto.Password);

            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    user = new User()
                    {
                        Login = dto.Login,
                        Password = hashedPassword,
                        Email = string.Empty
                    };

                    await _unitOfWork.Users.CreateAsync(user);

                    await _unitOfWork.SaveChangesAsync();

                    var userRole = new UserRole()
                    {
                        UserId = user.Id,
                        RoleId = defaultRole.Id
                    };

                    await _unitOfWork.UserRoles.CreateAsync(userRole);

                    await _unitOfWork.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }

            return new BaseResult<UserDto>()
            {
                Data = _mapper.Map<UserDto>(user)
            };
        }

        private static string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(bytes);
        }

        private static bool IsVerifyPassword(string userPasswordHashed, string userPassword)
        {
            var hash = HashPassword(userPassword);

            return hash.Equals(userPasswordHashed);
        }
    }
}
