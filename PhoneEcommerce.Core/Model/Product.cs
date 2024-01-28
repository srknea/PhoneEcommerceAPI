using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Model
{
    public class Product : BaseEntity
    {
        public string Color { get; set; }

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }

        public Guid ModelId { get; set; }
        public Model Model { get; set; }
        
        public Guid VersionId { get; set; }
        public Version Version { get; set; }

        //public List<OrderItem> OrderItems { get; set; }
    }
}
