using StockControl.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Model.Dao
{
    public class ProductDao : AbstractDao<Product>
    {    
        internal override dynamic Mapping(Product item)
        {
            return new
            {                
                Name = item.Name,
                Price = item.Price
            };
        }
        public IEnumerable<Product> GetProducts()
        {
            return this.FindAll();            
        }        

        public void InsertOrUpdate(Product product)
        {
            if (this.FindById(product.ProductId) == null)
            {
                Add(product);
            }
            else
            {
                Modify(product);
            }
        }
       
    }
}
