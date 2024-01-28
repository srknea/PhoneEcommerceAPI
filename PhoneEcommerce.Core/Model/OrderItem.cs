using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Model
{
    public class OrderItem : BaseEntity
    {   
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
