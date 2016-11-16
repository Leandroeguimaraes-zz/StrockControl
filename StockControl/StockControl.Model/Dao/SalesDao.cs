using StockControl.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Model.Dao
{
    public class SalesDao : AbstractDao<Sales>
    {    
       
        internal override object Mapping(Sales item)
        {
            return new
            {
               
                ProductId = item.ProductsSold.Keys.FirstOrDefault().ProductId,
                Name = item.ProductsSold.Keys.FirstOrDefault().Name,
                Quantity = item.ProductsSold.Values.FirstOrDefault()
            };
        }

        public void InsertOrUpdate(Sales product)
        {
            foreach (KeyValuePair<Product, int> p in product.ProductsSold)
            {
                if (this.FindById(p.Key.ProductId) == null)
                {
                    Add(product);
                }
                else
                {
                    Modify(product);
                }
            }
        }

        public IEnumerable<Sales>  GetProductsSold()
        {
            return this.FindAll();
        }
        
    }
}
