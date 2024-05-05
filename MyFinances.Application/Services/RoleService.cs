using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyFinances.Domain.DTO.Role;
using MyFinances.Domain.DTO.UserRole;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Repositories;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Services
{
    public class RoleService(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IRoleValidator roleValidator): IRoleService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IRoleValidator _roleValidator = roleValidator;

        public async Task<BaseResult<UserRoleDto>> SetRoleToUserAsync(AddUserRoleDto dto)
        {
            var user = await _unitOfWork.Users.GetAll()
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Login.Equals(dto.Login));

            var resultValidationOnUserRoleNotExist = _roleValidator.ValidateOnUserRoleNotExist(user, dto.RoleName);

            if (!resultValidationOnUserRoleNotExist.IsSuccess)
                return new BaseResult<UserRoleDto>()
                {
                    Failure = resultValidationOnUserRoleNotExist.Failure
                };

            var role = await _unitOfWork.Roles.GetAll().FirstOrDefaultAsync(x => x.Name.Equals(dto.RoleName));

            var resultValidationOnRoleExist = _roleValidator.ValidateOnNull(role);

            if (!resultValidationOnRoleExist.IsSuccess)
                return new BaseResult<UserRoleDto>()
                {
                    Failure = resultValidationOnRoleExist.Failure
                };

            UserRole userRole = new UserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            };

            await _unitOfWork.UserRoles.CreateAsync(userRole);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<UserRoleDto>()
            {
                Data = new UserRoleDto(user.Login, role.Name)
            };
        }

        public async Task<BaseResult<RoleDto>> CreateRoleAsync(string roleName)
        {
            var role = await _unitOfWork.Roles.GetAll().FirstOrDefaultAsync(x => x.Name.Equals(roleName));

            var resultValidationOnRoleExist = _roleValidator.ValidateOnNotNull(role);

            if (!resultValidationOnRoleExist.IsSuccess)
                return new BaseResult<RoleDto>()
                {
                    Failure = resultValidationOnRoleExist.Failure
                };

            role = new Role()
            {
                Name = roleName
            };

            await _unitOfWork.Roles.CreateAsync(role);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<RoleDto>()
            {
                Data = _mapper.Map<RoleDto>(role)
            };
        }

        public async Task<BaseResult<RoleDto>> DeleteRoleAsync(int id)
        {
            var role = await _unitOfWork.Roles.GetAll().FirstOrDefaultAsync(x => x.Id == id);

            var resultValidationOnNull = _roleValidator.ValidateOnNull(role);

            if (!resultValidationOnNull.IsSuccess)
                return new BaseResult<RoleDto>()
                {
                    Failure = resultValidationOnNull.Failure
                };

            _unitOfWork.Roles.Delete(role);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<RoleDto>()
            {
                Data = _mapper.Map<RoleDto>(role)
            };
        }

        public async Task<BaseResult<RoleDto>> UpdateRoleAsync(RoleDto dto)
        {
            var role = await _unitOfWork.Roles.GetAll().FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (role == null)
                return new BaseResult<RoleDto>()
                {
                    ErrorCode = (int)ErrorCodes.RoleNotFound,
                    ErrorMessage = ErrorMessage.RoleNotFound
                };

            role.Name = dto.Name;

            _unitOfWork.Roles.Update(role);

            await _unitOfWork.SaveChangeAsync();

            return new BaseResult<RoleDto>()
            {
                Data = _mapper.Map<RoleDto>(role)
            };
        }

        public async Task<BaseResult<UserRoleDto>> RemoveUserRole(RemoveUserRoleDto dto)
        {
            var user = await _unitOfWork.Users.GetAll()
               .Include(x => x.Roles)
               .FirstOrDefaultAsync(x => x.Login.Equals(dto.Login));

            if (user == null)
                return new BaseResult<UserRoleDto>()
                {
                    ErrorCode = (int)ErrorCodes.UserNotFound,
                    ErrorMessage = ErrorMessage.UserNotFound
                };

            var userRole = user.Roles.FirstOrDefault(x => x.Id == dto.RoleId);

            if (userRole == null)
                return new BaseResult<UserRoleDto>()
                {
                    ErrorCode = (int)ErrorCodes.RoleNotFound,
                    ErrorMessage = ErrorMessage.RoleNotFound
                };

            user.Roles.Remove(userRole);

            await _unitOfWork.SaveChangeAsync();

            return new BaseResult<UserRoleDto>()
            {
                Data = new UserRoleDto()
                {
                    Login = dto.Login,
                    RoleName = userRole.Name
                }
            };
        }
    }
}
