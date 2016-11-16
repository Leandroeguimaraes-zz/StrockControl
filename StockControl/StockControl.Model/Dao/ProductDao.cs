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
        /// <summary>
        /// Mapping the object to the insert/update columns.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The parameters with values.</returns>
        /// <remarks>In the default case, we take the object as is with no custom mapping.</remarks>
        internal override dynamic Mapping(Product item)
        {
            return new
            {                
                Name = item.Name,
                Price = item.Price
            };
        }
        /// <summary>
        /// Gets the products from DataBase and fill the comboBox
        /// </summary>        
        /// <returns>returns an IEnumerable</returns>
        public IEnumerable<Product> GetProducts()
        {
            return this.FindAll();            
        }
        /// <summary>
        /// Adds or updates a product to the DataBase
        /// </summary>
        /// <param name="product">The product.</param>
  
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
