using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Services
{
    public interface ICustomerService : IGenericService<Customer>
    {
        Task<CustomResponseDto<CustomerWithOrdersDto>> GetSingleCustomerByIdWithOrdersAsync(string modelId);
    }
}
