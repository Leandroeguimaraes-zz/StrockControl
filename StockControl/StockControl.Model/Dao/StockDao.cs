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

        private Product GetProduct(int ProdutoId)
        {
            ProductDao produtc = new ProductDao();
            return produtc.FindById(ProdutoId);
        }

        public int GetQuantityOfAProduct(int id)
        {
            Stock product = this.FindById(id);
            return product.Quantity;
        }

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
