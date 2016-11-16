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
        /// <summary>
        /// Mapping the object to the insert/update columns.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The parameters with values.</returns>
        /// <remarks>In the default case, we take the object as is with no custom mapping.</remarks>
        internal override object Mapping(Sales item)
        {
            return new
            {
               
                ProductId = item.ProductsSold.Keys.FirstOrDefault().ProductId,
                Name = item.ProductsSold.Keys.FirstOrDefault().Name,
                Quantity = item.ProductsSold.Values.FirstOrDefault()
            };
        }
        /// <summary>
        /// Adds or updates a product to the DataBase.
        /// </summary>
        /// <param name="product">The product.</param>      
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
        /// <summary>
        /// Gets all products sold from Database
        /// </summary>        
        /// <returns>Returns an IEnumerable</returns>
        public IEnumerable<Sales>  GetProductsSold()
        {
            return this.FindAll();
        }
        
    }
}
