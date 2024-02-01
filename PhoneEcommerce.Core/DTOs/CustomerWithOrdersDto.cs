using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.DTOs
{
    public class CustomerWithOrdersDto : CustomerDto
    {
        public List<OrderWithOrderItemsDto> Orders { get; set; }
    }
}
