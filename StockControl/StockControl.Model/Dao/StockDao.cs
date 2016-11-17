using StockControl.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockControl.Model.Dao
{
    public class StockDao : AbstractDao<Stock>
    {        
        public Stock Stock { get; set; }

        public StockDao()
        {
            this.Stock = GetFirstOrDefault();
        }

        /// <summary>
        /// Mapping the object to the insert/update columns.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The parameters with values.</returns>
        /// <remarks>In the default case, we take the object as is with no custom mapping.</remarks>
        internal override object Mapping(Stock item)
        {
            return new
            {
                ProductId = item.ProductId,
                Name = GetProduct(item.ProductId).Name,
                Quantity = item.Quantity,
                StockId = item.StockId
            };
        }

        /// <summary>
        /// Gets a product by Id
        /// </summary>
        /// <param name="ProductId">int.</param>
        /// <returns>Returns a product by Id determined.</returns>        
        private Product GetProduct(int productId)
        {
            ProductDao produtc = new ProductDao();
            return produtc.FindById(productId);
        }
        /// <summary>
        /// Gets the quantity of a product by Id
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>Returns the quantity of a product .</returns>        
        public int GetQuantityOfAProduct(int id)
        {
            Stock product = this.FindById(id);
            return product.Quantity;
        }
        /// <summary>
        /// Updates a product in the stock
        /// </summary>
        /// <param name="product">Stock.</param>            
        public void Update(Stock product)
        {
            try
            {
                Stock productUpdated = this.SubstractsQuantityOfAProduct(product);

                Modify(productUpdated);
            }
            catch (Exception)
            {

                throw new System.ArgumentException("Quantidade do produto não foi atualizado no stock");
            }
           
        }
        /// <summary>
        /// Substracts the quantity of a product in the stock
        /// </summary>
        /// <param name="product">Stock.</param>
        /// <returns>Returns the product with its updated quantity .</returns>        
        private Stock SubstractsQuantityOfAProduct(Stock product)
        {
            Stock productFromStock = Find(d => d.ProductId == product.Product.ProductId).FirstOrDefault();
            
            if(productFromStock != null && productFromStock.Quantity >= product.Quantity)
            {
                productFromStock.Quantity -= product.Quantity;
            }
            else
            {
                MessageBox.Show(" Produto em falta no estoque");
            }

            return productFromStock;
        }
       
    }
}
