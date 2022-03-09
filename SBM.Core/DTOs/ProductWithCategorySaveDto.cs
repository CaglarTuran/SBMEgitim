﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBM.Core.DTOs
{
    public class ProductWithCategorySaveDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public string CategoryName { get; set; }
    }
}