using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Model
{
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; }

        public List<Model> Models { get; set; }
    }
}
