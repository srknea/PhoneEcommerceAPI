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
    public class VersionRepository : GenericRepository<Core.Model.Version>, IVersionRepository
    {
        public VersionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
