using Microsoft.EntityFrameworkCore;
using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Repository.Repositories
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {
        public ModelRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Model> GetSingleModelByIdWithVerisonsAsync(int modelId)
        {
            return await _context.Models.Include(x => x.Versions).Where(x => x.Id == modelId).SingleOrDefaultAsync(x => x.Id == modelId);
        }
    }
}
