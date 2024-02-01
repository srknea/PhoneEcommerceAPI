using AutoMapper;
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
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ModelService(IGenericRepository<Model> repository, IUnitOfWork unitOfWork, IModelRepository modelRepository, IMapper mapper, IVersionService versionService, IProductService productService) : base(repository, unitOfWork)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _versionService = versionService;
            _productService = productService;
        }

        public async Task<CustomResponseDto<ModelWithVersionsDto>> GetSingleModelByIdWithVersionAsync(string modelId)
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

        public async Task<CustomResponseDto<VersionDto>> AddVersionToModel(string modelId, CreateVersionDto createVersionDto)
        {
            var model = await _modelRepository.GetByIdAsync(modelId);

            if (model == null)
            {
                throw new NotFoundException($"Model with Id '{modelId}' not found");
            }

            
            var version = _mapper.Map<Core.Model.Version>(createVersionDto);
            version.ModelId = Guid.Parse(modelId);

            var addedVersion = await _versionService.AddAsync(version);

            // Product oluştur
            var newProduct = new Product
            {
                VersionId = addedVersion.Id,
                Version = addedVersion
            };

            // ProductService ile Product'ı ekleme
            await _productService.AddAsync(newProduct);


            var addedVersionDto = _mapper.Map<VersionDto>(addedVersion);

            return CustomResponseDto<VersionDto>.Success(201, addedVersionDto);
        }

    }
}
