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
    public class ModelService : GenericService<Model>, IModelService
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public ModelService(IGenericRepository<Model> repository, IUnitOfWork unitOfWork, IModelRepository modelRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
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
    }
}
