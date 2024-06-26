﻿using AutoMapper;
using FluentValidation;
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
        IRoleValidator roleValidator,
        IValidator<AddUserRoleDto> addUserRoleDtoValidator,
        IValidator<RemoveUserRoleDto> removeUserRoleDtoValidator): IRoleService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IRoleValidator _roleValidator = roleValidator;
        private readonly IValidator<AddUserRoleDto> _addUserRoleDtoValidator = addUserRoleDtoValidator;
        private readonly IValidator<RemoveUserRoleDto> _removeUserRoleDtoValidator = removeUserRoleDtoValidator;

        public async Task<BaseResult<UserRoleDto>> SetRoleToUserAsync(AddUserRoleDto dto)
        {
            var resultDtoValidation = _addUserRoleDtoValidator.Validate(dto);

            if (!resultDtoValidation.IsValid)
            {
                var error = resultDtoValidation.Errors.FirstOrDefault();

                return new BaseResult<UserRoleDto>()
                {
                    Failure = Error.Validation(error.ErrorCode, error.ErrorMessage)
                };
            }

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

            var resultValidationOnNull = _roleValidator.ValidateOnNull(role);

            if (!resultValidationOnNull.IsSuccess)
                return new BaseResult<RoleDto>()
                {
                    Failure = resultValidationOnNull.Failure
                };

            role.Name = dto.Name;

            _unitOfWork.Roles.Update(role);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<RoleDto>()
            {
                Data = _mapper.Map<RoleDto>(role)
            };
        }

        public async Task<BaseResult<UserRoleDto>> RemoveUserRole(RemoveUserRoleDto dto)
        {
            var resultDtoValidation = _removeUserRoleDtoValidator.Validate(dto);

            if (!resultDtoValidation.IsValid)
            {
                var error = resultDtoValidation.Errors.FirstOrDefault();

                return new BaseResult<UserRoleDto>()
                {
                    Failure = Error.Validation(error.ErrorCode, error.ErrorMessage)
                };
            }

            var user = await _unitOfWork.Users.GetAll()
               .Include(x => x.Roles)
               .FirstOrDefaultAsync(x => x.Login.Equals(dto.Login));

            var resultValidationOnUserRoleExist = _roleValidator.ValidateOnUserRoleExist(user, dto.RoleName);

            if (!resultValidationOnUserRoleExist.IsSuccess)
                return new BaseResult<UserRoleDto>()
                {
                    Failure = resultValidationOnUserRoleExist.Failure
                };

            var role = await _unitOfWork.Roles.GetAll().FirstOrDefaultAsync(x => x.Name.Equals(dto.RoleName));

            var userRole = await _unitOfWork.UserRoles.GetAll().FirstOrDefaultAsync(x => x.UserId == user.Id && x.RoleId == role.Id);

            _unitOfWork.UserRoles.Delete(userRole);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<UserRoleDto>()
            {
                Data = new UserRoleDto(user.Login, role.Name)
            };
        }
    }
}
