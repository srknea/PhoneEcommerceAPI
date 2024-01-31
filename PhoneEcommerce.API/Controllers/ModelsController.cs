using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Services;
using PhoneEcommerce.Service.Services;

namespace PhoneEcommerce.API.Controllers
{
    [AllowAnonymous]
    public class ModelsController : CustomBaseController
    {
        private readonly IModelService _modelService;
        private readonly IMapper _mapper;

        public ModelsController(IModelService modelService, IMapper mapper)
        {
            _modelService = modelService;
            _mapper = mapper;
        }

        [HttpGet("{modelId}")]
        public async Task<IActionResult> GetById(int modelId)
        {

            var model = await _modelService.GetByIdAsync(modelId);

            var modelDto = _mapper.Map<ModelDto>(model);

            return CreateActionResult(CustomResponseDto<ModelDto>.Success(200, modelDto));
        }

        [HttpPut("{modelId}")]
        public async Task<IActionResult> Update(int modelId, [FromBody] UpdateModelDto updataModelDto)
        {

            var model = _mapper.Map<Model>(updataModelDto);
            model.Id = modelId;

            await _modelService.UpdateAsync(model);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{modelId}")]
        public async Task<IActionResult> Remove(int modelId)
        {
            var model = await _modelService.GetByIdAsync(modelId);

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
