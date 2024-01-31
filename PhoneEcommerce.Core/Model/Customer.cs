using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Model
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } // TODO: Add validation
        public string PhoneNumber { get; set; } // TODO: Add validation
        public string Address { get; set; }
        public string PostalCode { get; set; } // TODO: Add validation

        public List<Order> Orders { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
