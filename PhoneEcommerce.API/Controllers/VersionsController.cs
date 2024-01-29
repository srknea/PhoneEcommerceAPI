using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Services;
using PhoneEcommerce.Service.Services;

namespace PhoneEcommerce.API.Controllers
{
    public class VersionsController : CustomBaseController
    {
        private readonly IVersionService _versionService;
        private readonly IMapper _mapper;

        public VersionsController(IMapper mapper, IVersionService versionService)
        {
            _mapper = mapper;
            _versionService = versionService;
        }

        /*
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var models = await _modelService.GetAllAsync();

            var modelsDto = _mapper.Map<List<ModelDto>>(models.ToList());

            return CreateActionResult(CustomResponseDto<List<ModelDto>>.Success(200, modelsDto));

        }
        */

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var version = await _versionService.GetByIdAsync(id);

            var versionDto = _mapper.Map<VersionDto>(version);

            return CreateActionResult(CustomResponseDto<VersionDto>.Success(200, versionDto));
        }

        /*
        [HttpPost]
        public async Task<IActionResult> Save(ModelDto dto)
        {
            var model = await _modelService.AddAsync(_mapper.Map<Model>(dto));

            var modelDto = _mapper.Map<ModelDto>(model);

            return CreateActionResult(CustomResponseDto<ModelDto>.Success(201, modelDto));
            // 201 : Oluşturuldu anlamında kullanılır. İşlem başarılı ise 201 döndürülebilir.
        }
        */


        [HttpPut("{versionId}")]
        public async Task<IActionResult> Update(int versionId, UpdateVersionDto updateVersionDto)
        {

            var version = _mapper.Map<Core.Model.Version>(updateVersionDto);
            version.Id = versionId;

            await _versionService.UpdateAsync(version);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var version = await _versionService.GetByIdAsync(id);

            await _versionService.RemoveAsync(version);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
