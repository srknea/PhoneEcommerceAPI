using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.DTOs
{
    public class ModelDto : BaseDto
    {
        public string ModelName { get; set; }
        public int BrandId { get; set; }
    }
}
