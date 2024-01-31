using PhoneEcommerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Repositories
{
    public interface IModelRepository : IGenericRepository<Core.Model.Model>
    {
        Task<Core.Model.Model> GetSingleModelByIdWithVerisonsAsync(string modelId);
    }
}
