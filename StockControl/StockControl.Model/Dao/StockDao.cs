using StockControl.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Model.Dao
{
    public class StockDao : AbstractDao<Stock>
    {
        private Stock stock;

        public StockDao()
        {
            this.stock = GetFirstOrDefault();
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
                ProductId = item.Product.ProductId,
                ProductName = item.Product.Name,
                Quantity = item.Quantity
            };
        }
       
    }
}
