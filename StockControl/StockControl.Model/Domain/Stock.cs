﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Model.Domain
{
    public class Stock
    {
        public int StockId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Stock( Product product, int quantity)
        {           
            this.Product = product;
            this.Quantity = quantity;
        }
    }
}
