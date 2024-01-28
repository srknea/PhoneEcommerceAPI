using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.DTOs
{
    public class VersionDto : BaseDto
    {
        public string StorageCapacity { get; set; }
        public decimal Price { get; set; }
        public bool StockStatus { get; set; }

        public int ModelId { get; set; }
    }
}
