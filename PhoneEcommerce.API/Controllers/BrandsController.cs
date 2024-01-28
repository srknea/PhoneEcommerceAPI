using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Services;

namespace PhoneEcommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : CustomBaseController
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var brands = await _brandService.GetAllAsync();

            var brandsDto = _mapper.Map<List<BrandDto>>(brands.ToList());

            return CreateActionResult(CustomResponseDto<List<BrandDto>>.Success(200, brandsDto));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var brand = await _brandService.GetByIdAsync(id);

            var brandDto = _mapper.Map<BrandDto>(brand);

            return CreateActionResult(CustomResponseDto<BrandDto>.Success(200, brandDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(BrandDto dto)
        {
            var brand = await _brandService.AddAsync(_mapper.Map<Brand>(dto));

            var brandDto = _mapper.Map<BrandDto>(brand);

            return CreateActionResult(CustomResponseDto<BrandDto>.Success(201, brandDto));
            // 201 : Oluşturuldu anlamında kullanılır. İşlem başarılı ise 201 döndürülebilir.
        }

        [HttpPut]
        public async Task<IActionResult> Update(BrandDto brandDto)
        {
            await _brandService.UpdateAsync(_mapper.Map<Brand>(brandDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);

            await _brandService.RemoveAsync(brand);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
