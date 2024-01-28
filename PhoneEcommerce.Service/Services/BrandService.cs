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
    public class BrandService : GenericService<Brand>, IBrandService
    {
        public BrandService(IGenericRepository<Brand> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
