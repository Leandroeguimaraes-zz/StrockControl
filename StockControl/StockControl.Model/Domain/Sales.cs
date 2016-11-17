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
        public int ProductId { get; set; }
        public int SalesId { get; set; }
        public ObservableDictionary<Product,int> ProductsSold { get; set; }

        //Dapper nao mapeia o objeto ProductsSold, então é necessario criar a propriedade(s) desejada(s) (Name e Quantity)
        public string Name { get; set; }

        public int Quantity { get; set; }
      
        
    }


}
