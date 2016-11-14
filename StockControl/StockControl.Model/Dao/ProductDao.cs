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
        private Product product;

        internal override dynamic Mapping(Product item)
        {
            return new
            {
                Name = item.Name,
                Price = item.Price
            };
        }
        
        public void SetName(string name)
        {
            if (this.product == null)
            {
                this.product = new Product();
                this.product.Name = name;
                Add(this.product);
            }
            else
            {
                this.product.Name = name;
                Modify(this.product);
            }
        }
        public string GetName()
        {
            if (this.product == null)
            {
                return null;
            }
            else
            {
                return this.product.Name;
            }
        }
        public void SetPrice(double price)
        {
            if (this.product == null)
            {
                this.product = new Product();
                this.product.Price = price;
                Add(product);
            }
            else
            {
                this.product.Price = price;
                Modify(this.product);
            }
        }
        public double GetPrice()
        {
            if (this.product == null)
            {
                return -1;
            }
            else
            {
                return this.product.Price;
            }

        }
    }
}
