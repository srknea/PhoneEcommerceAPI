using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Repositories;
using PhoneEcommerce.Core.Services;
using PhoneEcommerce.Core.UnitOfWork;
using PhoneEcommerce.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Service.Services
{
    public class BrandService : GenericService<Brand>, IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IModelService _modelService;
        private readonly IMapper _mapper;

        public BrandService(IGenericRepository<Brand> repository, IUnitOfWork unitOfWork, IBrandRepository brandRepository, IMapper mapper, IModelService modelService) : base(repository, unitOfWork)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _modelService = modelService;
        }

        public async Task<CustomResponseDto<BrandWithModelsDto>> GetSingleBrandByWithModelAsync(string brandId)
        {
            var hasBrand= await _brandRepository.GetByIdAsync(brandId);

            if (hasBrand == null)
            {
                throw new NotFoundException($"Brand with Id '{brandId}' not found");
            }

            var brand = await _brandRepository.GetSingleBrandByIdWithModelAsync(brandId);

            var brandDto = _mapper.Map<BrandWithModelsDto>(brand);

            return CustomResponseDto<BrandWithModelsDto>.Success(200, brandDto);
        }

        public async Task<CustomResponseDto<ModelDto>> AddModelToBrand(string brandId, [FromBody] CreateModelDto createModelDto)
        {
            // Belirtilen brandId'ye sahip markayı kontrol et
            var brand = await _brandRepository.GetByIdAsync(brandId);

            if (brand == null)
            {
                throw new NotFoundException($"Brand with Id '{brandId}' not found");
            }

            // ModelDto'dan Model nesnesine dönüştürme
            var model = _mapper.Map<Model>(createModelDto);
            model.BrandId = Guid.Parse(brandId); // Model'in bağlı olduğu marka Id'sini ayarla

            // Modeli ekleyerek işlemi gerçekleştir
            var addedModel = await _modelService.AddAsync(model);

            // Eklenen modeli ModelDto'ya dönüştürme
            var addedModelDto = _mapper.Map<ModelDto>(addedModel);

            return CustomResponseDto<ModelDto>.Success(201, addedModelDto);
        }
    }
}
