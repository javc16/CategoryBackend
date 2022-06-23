using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryBackend.AuthScope
{
    public class User : IdentityUser
    {
        public string name { get; set; }
    }
}
