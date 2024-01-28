using AutoMapper;
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
        private readonly IMapper _mapper;

        public BrandService(IGenericRepository<Brand> repository, IUnitOfWork unitOfWork, IBrandRepository brandRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<BrandWithModelsDto>> GetSingleBrandByWithModelAsync(int brandId)
        {
            var hasCategory = await _brandRepository.GetByIdAsync(brandId);

            if (hasCategory == null)
            {
                throw new NotFoundException($"Brand with Id '{brandId}' not found");
            }

            var brand = await _brandRepository.GetSingleBrandByIdWithModelAsync(brandId);

            var brandDto = _mapper.Map<BrandWithModelsDto>(brand);

            return CustomResponseDto<BrandWithModelsDto>.Success(200, brandDto);
        }
    }
}
