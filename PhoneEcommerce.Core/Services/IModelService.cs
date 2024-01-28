using PhoneEcommerce.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Services
{
    public interface IModelService : IGenericService<PhoneEcommerce.Core.Model.Model>
    {
        Task<CustomResponseDto<ModelWithVersionsDto>> GetSingleModelByIdWithVersionAsync(int modelId);
    }
}
