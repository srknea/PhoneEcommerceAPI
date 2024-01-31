using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Services;
using PhoneEcommerce.Service.Services;

namespace PhoneEcommerce.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : CustomBaseController
    {
        private readonly IBrandService _brandService;
        private readonly IModelService _modelService;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService brandService, IMapper mapper, IModelService modelService)
        {
            _brandService = brandService;
            _mapper = mapper;
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var brands = await _brandService.GetAllAsync();

            var brandsDto = _mapper.Map<List<BrandDto>>(brands.ToList());

            return CreateActionResult(CustomResponseDto<List<BrandDto>>.Success(200, brandsDto));

        }

        [HttpGet("{brandId}")]
        public async Task<IActionResult> GetById(string brandId)
        {

            var brand = await _brandService.GetByIdAsync(brandId);

            var brandDto = _mapper.Map<BrandDto>(brand);

            return CreateActionResult(CustomResponseDto<BrandDto>.Success(200, brandDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CreateBrandDto dto)
        {
            var brand = await _brandService.AddAsync(_mapper.Map<Brand>(dto));

            var brandDto = _mapper.Map<BrandDto>(brand);

            return CreateActionResult(CustomResponseDto<BrandDto>.Success(201, brandDto));
            // 201 : Oluşturuldu anlamında kullanılır. İşlem başarılı ise 201 döndürülebilir.
        }

        [HttpPut("{brandId}")]
        public async Task<IActionResult> Update(string brandId, [FromBody] UpdateBrandDto updateBrandDto)
        {

            var brand = _mapper.Map<Brand>(updateBrandDto);
            brand.Id = Guid.Parse(brandId); 

            await _brandService.UpdateAsync(brand);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{brandId}")]
        public async Task<IActionResult> Remove(string brandId)
        {
            var brand = await _brandService.GetByIdAsync(brandId);

            await _brandService.RemoveAsync(brand);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("{brandId}/models")]
        public async Task<IActionResult> GetSingleBrandByIdWithModels(string brandId)
        {
            return CreateActionResult(await _brandService.GetSingleBrandByWithModelAsync(brandId));
        }

        [HttpPost("{brandId}/models")]
        public async Task<IActionResult> AddModelToBrand(string brandId, [FromBody] CreateModelDto createModelDto)
        {
            return CreateActionResult(await _brandService.AddModelToBrand(brandId, createModelDto));
        }
    }
}
