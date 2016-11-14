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
        private Sales sales;

        public SalesDao()
        {

        }
        internal override object Mapping(Sales item)
        {
            return new
            {
                ProductId = item.ProductsSold.Keys.FirstOrDefault().ProductId,
                ProductName = item.ProductsSold.Keys.FirstOrDefault().Name,
                Quantity = item.ProductsSold.Values.FirstOrDefault()
            };
        }
        public void SetProductId(int id)
        {
            if (this.sales == null)
            {
                this.sales = new Sales();
                this.sales.ProductsSold.Keys.FirstOrDefault().ProductId = id;
                Add(this.sales);
            }
            else
            {
                this.sales.ProductsSold.Keys.FirstOrDefault().ProductId = id;
                Modify(this.sales);
            }
        }
        public int GetProductId()
        {
            if (this.sales == null)
            {
                return -1;
            }
            else
            {
                return this.sales.ProductsSold.FirstOrDefault().Key.ProductId;
            }
        }
        public void SetName(string name)
        {
            if (this.sales == null)
            {
                this.sales = new Sales();
                this.sales.ProductsSold.Keys.FirstOrDefault().Name = name;
                Add(this.sales);
            }
            else
            {
                this.sales.ProductsSold.Keys.FirstOrDefault().Name = name;
                Modify(this.sales);
            }
        }
        public string GetName()
        {
            if (this.sales == null)
            {
                return null;
            }
            else
            {
                return this.sales.ProductsSold.Keys.FirstOrDefault().Name;
            }
        }
        public void SetQuantity(int quantity)
        {
            if (this.sales == null)
            {
                //this.sales = new Sales();
                //this.sales.ProductsSold.Values.First()= quantity;
                //Add(sales);
            }
            else
            {
                //sales.Quantity = quantity;
                //Modify(sales);
            }
        }
        public double GetQuantity()
        {
            if (this.sales == null)
            {
                return -1;
            }
            else
            {
                return this.sales.ProductsSold.Values.FirstOrDefault();
            }

        }
    }
}
