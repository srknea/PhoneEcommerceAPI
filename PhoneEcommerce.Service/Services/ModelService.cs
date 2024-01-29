﻿using AutoMapper;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Repositories;
using PhoneEcommerce.Core.Services;
using PhoneEcommerce.Core.UnitOfWork;
using PhoneEcommerce.Repository.Repositories;
using PhoneEcommerce.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Service.Services
{
    public class ModelService : GenericService<Model>, IModelService
    {
        private readonly IModelRepository _modelRepository;
        private readonly IVersionService _versionService;
        private readonly IMapper _mapper;

        public ModelService(IGenericRepository<Model> repository, IUnitOfWork unitOfWork, IModelRepository modelRepository, IMapper mapper, IVersionService versionService) : base(repository, unitOfWork)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _versionService = versionService;
        }

        public async Task<CustomResponseDto<ModelWithVersionsDto>> GetSingleModelByIdWithVersionAsync(int modelId)
        {
            var hasModel = await _modelRepository.GetByIdAsync(modelId);

            if (hasModel == null)
            {
                throw new NotFoundException($"Model with Id '{modelId}' not found");
            }

            var model = await _modelRepository.GetSingleModelByIdWithVerisonsAsync(modelId);

            var modelDto = _mapper.Map<ModelWithVersionsDto>(model);

            return CustomResponseDto<ModelWithVersionsDto>.Success(200, modelDto);
        }

        public async Task<CustomResponseDto<VersionDto>> AddVersionToModel(int modelId, CreateVersionDto createVersionDto)
        {
            var model = await _modelRepository.GetByIdAsync(modelId);

            if (model == null)
            {
                throw new NotFoundException($"Model with Id '{modelId}' not found");
            }

            
            var version = _mapper.Map<Core.Model.Version>(createVersionDto);
            version.ModelId = modelId;

            
            var addedVersion = await _versionService.AddAsync(version);

            
            var addedVersionDto = _mapper.Map<VersionDto>(addedVersion);

            return CustomResponseDto<VersionDto>.Success(201, addedVersionDto);
        }

    }
}
