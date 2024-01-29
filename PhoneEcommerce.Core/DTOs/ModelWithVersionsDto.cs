using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.DTOs
{
    public class ModelWithVersionsDto : ModelDto
    {
        public List<VersionDto> Versions { get; set; }
    }
}
