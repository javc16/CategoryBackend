using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryBackend.AuthScope
{
    public class ApplicationSettingsDTO
    {
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
    }
}
