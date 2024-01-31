﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Core.Model
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }

        public Customer Customer { get; set; }
    }
}
