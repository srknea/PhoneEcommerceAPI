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
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Customer> GetSingleCustomerByIdWithOrdersAsync(int customerId)
        {
            return await _context.Customers.Include(x => x.Orders).Where(x => x.Id == customerId).SingleOrDefaultAsync(x => x.Id == customerId);
        }
    }
}
