﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CategoryBackend.Category
{
    public class CategoryDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int isActive { get; set; }
    }
}
