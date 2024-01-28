using PhoneEcommerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Repositories
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Task<Brand> GetSingleBrandByIdWithModelAsync(int modelId);
    }
}
