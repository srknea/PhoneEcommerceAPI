using PhoneEcommerce.Core.Model;
using PhoneEcommerce.Core.Repositories;
using PhoneEcommerce.Core.Services;
using PhoneEcommerce.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Service.Services
{
    public class ModelService : GenericService<Model>, IModelService
    {
        public ModelService(IGenericRepository<Model> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {

        }
    }
}
