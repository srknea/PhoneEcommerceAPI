using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Model
{
    public class Model : BaseEntity
    {
        public string ModelName { get; set; }

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Version> Versions { get; set; }
    }
}
