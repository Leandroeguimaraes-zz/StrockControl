﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Model.Domain
{
    public class Stock
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}