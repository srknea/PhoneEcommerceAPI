using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Services;
using PhoneEcommerce.Service.Services;

namespace PhoneEcommerce.API.Controllers
{
    public class ModelsController : CustomBaseController
    {
        private readonly IModelService _modelService;
        private readonly IMapper _mapper;

        public ModelsController(IModelService modelService, IMapper mapper)
        {
            _modelService = modelService;
            _mapper = mapper;
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

            var model = await _modelService.GetByIdAsync(id);

            var modelDto = _mapper.Map<ModelDto>(model);

            return CreateActionResult(CustomResponseDto<ModelDto>.Success(200, modelDto));
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

        [HttpPut]
        public async Task<IActionResult> Update(ModelDto modelDto)
        {
            await _modelService.UpdateAsync(_mapper.Map<Model>(modelDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var model = await _modelService.GetByIdAsync(id);

            await _modelService.RemoveAsync(model);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet("{modelId}/versions")]
        public async Task<IActionResult> GetSingleModelByIdWithVersions(int modelId)
        {
            return CreateActionResult(await _modelService.GetSingleModelByIdWithVersionAsync(modelId));
        }

        [HttpPost("{modelId}/versions")]
        public async Task<IActionResult> AddVersionToModel(int modelId, [FromBody] CreateVersionDto createVersionDto)
        {
            return CreateActionResult(await _modelService.AddVersionToModel(modelId, createVersionDto));
        }
    }
}
