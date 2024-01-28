using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Services
{
    public interface IBrandService : IGenericService<Brand>
    {
        Task<CustomResponseDto<BrandWithModelsDto>> GetSingleBrandByWithModelAsync(int brandId);
    }
}
