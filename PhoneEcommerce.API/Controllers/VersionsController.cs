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
    public class VersionsController : CustomBaseController
    {
        private readonly IVersionService _versionService;
        private readonly IMapper _mapper;

        public VersionsController(IMapper mapper, IVersionService versionService)
        {
            _mapper = mapper;
            _versionService = versionService;
        }

        [HttpGet("{versionId}")]
        public async Task<IActionResult> GetById(string versionId)
        {

            var version = await _versionService.GetByIdAsync(versionId);

            var versionDto = _mapper.Map<VersionDto>(version);

            return CreateActionResult(CustomResponseDto<VersionDto>.Success(200, versionDto));
        }

        [HttpPut("{versionId}")]
        public async Task<IActionResult> Update(string versionId, UpdateVersionDto updateVersionDto)
        {

            var version = _mapper.Map<Core.Model.Version>(updateVersionDto);
            version.Id = Guid.Parse(versionId);

            await _versionService.UpdateAsync(version);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{versionId}")]
        public async Task<IActionResult> Remove(string versionId)
        {
            var version = await _versionService.GetByIdAsync(versionId);

            await _versionService.RemoveAsync(version);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
