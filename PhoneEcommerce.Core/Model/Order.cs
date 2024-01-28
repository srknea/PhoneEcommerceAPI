using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Model
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public bool OrderStatus { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
