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

        internal override object Mapping(Stock item)
        {
            return new
            {
                ProductId = item.Product.ProductId,
                ProductName = item.Product.Name,
                Quantity = item.Quantity
            };
        }
        public void SetProductId(int id)
        {
            if (this.stock == null)
            {
                this.stock = new Stock();
                this.stock.Product.ProductId = id;
                Add(this.stock);
            }
            else
            {
                this.stock.Product.ProductId = id;
                Modify(this.stock);
            }
        }
        public int GetProductId()
        {
            if (this.stock == null)
            {
                return -1;
            }
            else
            {
                return this.stock.Product.ProductId;
            }
        }
        public void SetName(string name)
        {
            if (this.stock == null)
            {
                this.stock = new Stock();
                this.stock.Product.Name = name;
                Add(this.stock);
            }
            else
            {
                this.stock.Product.Name = name;
                Modify(this.stock);
            }
        }
        public string GetName()
        {
            if(this.stock == null)
            {
                return null;
            }
            else
            {
                return this.stock.Product.Name;
            }
        }
        public void SetQuantity(int quantity)
        {
            if (this.stock == null)
            {
                this.stock = new Stock();
                this.stock.Quantity = quantity;
                Add(this.stock);
            }
            else
            {
                this.stock.Quantity = quantity;
                Modify(this.stock);
            }
        }
        public double GetQuantity()
        {
            if (this.stock == null)
            {
                return -1;
            }
            else
            {
                return this.stock.Quantity;
            }

        }
    }
}
