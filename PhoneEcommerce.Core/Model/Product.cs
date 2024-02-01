using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Model
{
    public class Product : BaseEntity
    {
        public Guid VersionId { get; set; }
        public Version Version { get; set; }

        //public List<OrderItem> OrderItems { get; set; }
    }
}
