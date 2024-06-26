﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyFinances.Domain.DTO.OperationType;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Repositories;
using MyFinances.Domain.Interfaces.Services;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;
using Serilog;

namespace MyFinances.Application.Services
{
    public class OperationTypeService(
        ILogger logger,
        IUnitOfWork unitOfWork,
        IOperationTypeValidator operationTypeValidator,
        IMapper mapper): IOperationTypeService
    {
        private readonly ILogger _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IOperationTypeValidator _operationTypeValidator = operationTypeValidator;
        private readonly IMapper _mapper = mapper;

        public async Task<BaseResult<OperationTypeDto>> AddOperationType(string srcPath)
        {
            var type = await _unitOfWork.OperationTypes
                .GetAll()
                .FirstOrDefaultAsync(x => x.IconSrc.Equals(srcPath));

            var resultValidation = _operationTypeValidator.AddOperationTypeValidator(type);

            if (!resultValidation.IsSuccess)
                return new BaseResult<OperationTypeDto>()
                {
                    Failure = resultValidation.Failure
                };

            type = new OperationType() { IconSrc = srcPath };

            await _unitOfWork.OperationTypes.CreateAsync(type);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<OperationTypeDto>()
            {
                Data = _mapper.Map<OperationTypeDto>(type)
            };
        }

        public async Task<BaseResult<OperationTypeDto>> AddTypeAssociation(int typeId, string association)
        {
            var clearedAssociation = ClearAssociation(association);

            var type = await _unitOfWork.OperationTypes
                .GetAll()
                .FirstOrDefaultAsync(x => x.Id == typeId);

            var typeAssociation = await _unitOfWork.TypeAssociations
                .GetAll()
                .FirstOrDefaultAsync(x => x.TypeId.Equals(typeId) && x.Association.Equals(clearedAssociation));

            var resultValidation = _operationTypeValidator.AddTypeAssociationValidator(type, typeAssociation);

            if (!resultValidation.IsSuccess)
                return new BaseResult<OperationTypeDto>()
                {
                    Failure = resultValidation.Failure
                };

            var newAssociation = new TypeAssociation()
            {
                Association = clearedAssociation,
                TypeId = typeId
            };

            await _unitOfWork.TypeAssociations.CreateAsync(newAssociation);

            await _unitOfWork.SaveChangesAsync();

            return new BaseResult<OperationTypeDto>
            {
                Data = _mapper.Map<OperationTypeDto>(type)
            };
        }

        public async Task<CollectionResult<OperationTypeDto>> GetAllTypes()
        {
            var operationTypes = _unitOfWork.OperationTypes
                .GetAll()
                .Select(x => _mapper.Map<OperationTypeDto>(x));

            return new CollectionResult<OperationTypeDto>
            {
                Count = operationTypes.Count(),
                Data = operationTypes
            };
        }

        public async Task<CollectionResult<OperationTypeDto>> GetTypesByAssociation(string association)
        {
            var clearedAssociation = ClearAssociation(association);

            var associationsWithTypes = _unitOfWork.TypeAssociations
                .GetAll()
                .Include(x => x.Type)
                .ToList()
                .Where(x => ClearAssociation(x.Association).Contains(clearedAssociation));

            var uniqueTypes = associationsWithTypes
                .Select(x => x.TypeId)
                .ToHashSet()
                .ToList();

            var operationTypes = associationsWithTypes
                .Where(x => uniqueTypes.Any(id => id == x.TypeId))
                .Select(x => x.Type);

            return new CollectionResult<OperationTypeDto>()
            {
                Count = operationTypes.Count(),
                Data = operationTypes.Select(x => _mapper.Map<OperationTypeDto>(x))
            };
        }

        private string ClearAssociation(string rawAssociation) => rawAssociation.Trim().ToLower();
    }
}
