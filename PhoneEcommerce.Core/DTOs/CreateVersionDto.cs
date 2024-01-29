using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.DTOs
{
    public class CreateVersionDto
    {
        public string StorageCapacity { get; set; }
        public decimal Price { get; set; }
        public bool StockStatus { get; set; }
    }
}
