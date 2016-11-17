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

                //ProductId = item.ProductsSold.Keys.FirstOrDefault().ProductId,
                //Name = item.ProductsSold.Keys.FirstOrDefault().Name,
                //Quantity = item.ProductsSold.Values.FirstOrDefault()
                ProductId = item.ProductId,
                Name = item.Name,
                Quantity = item.Quantity
            };
        }
        /// <summary>
        /// Adds or updates a product to the DataBase.
        /// </summary>
        /// <param name="product">The product.</param>      
        public void Insert(Sales product)
        {
            try
            {
                foreach (KeyValuePair<Product, int> p in product.ProductsSold)
                {
                    Sales sales = new Sales();

                    sales.ProductId = p.Key.ProductId;
                    sales.Name = p.Key.Name;
                    sales.Quantity = p.Value;

                    Add(sales);                                        
                }
            }
            catch (Exception ex)
            {

                throw new System.ArgumentException("Deu ruim - Produto não foi adicionado a lista de comprados");
            }
            
        }
        /// <summary>
        /// Gets all products sold from Database
        /// </summary>        
        /// <returns>Returns Returns all products sold from Sales table</returns>
        public IEnumerable<Sales> GetProductsSold()
        {
            return this.FindAll();
        }
        
    }
}
