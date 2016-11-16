using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Model.Domain
{
    public class Sales
    {
        public int SalesId { get; set; }
        public ObservableDictionary<Product,int> ProductsSold { get; set; }
    }
}
