using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Model
{
    public class Version : BaseEntity
    {
        public string StorageCapacity { get; set; }
        public decimal Price { get; set; }
        public bool StockStatus { get; set; }

        public Guid ModelId { get; set; }
        public Model Model { get; set; }

        public List<Product> Products { get; set; }
    }
}
