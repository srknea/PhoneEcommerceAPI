using PhoneEcommerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.DTOs
{
    public class OrderItemDto
    {
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
