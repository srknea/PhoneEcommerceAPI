using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.DTOs
{
    public class OrderWithOrderItemsDto : BaseDto
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool OrderStatus { get; set; }

        public Guid CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
