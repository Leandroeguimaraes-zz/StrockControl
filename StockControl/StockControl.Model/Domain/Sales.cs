using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Model.Domain
{
    public class Sales
    {
        public int SalesId { get; set; }
        public Dictionary<Product,int> ProductsSold { get; set; }
    }
}
