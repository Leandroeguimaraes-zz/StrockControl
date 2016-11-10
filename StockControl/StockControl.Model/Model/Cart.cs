using StockControl.Model.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.Model.Model
{
    public class Cart
    {
        public ObservableDictionary<Product, int> ListCart { get; set; }

        public Cart()
        {           
            this.ListCart = new ObservableDictionary<Product, int>();
        }
        public void ReceiveProduct(Product product, int quantity)
        {
            if (ListCart.ContainsKey(product))
            {
                //KeyValuePair<Product, int> productOld = ListCart.Where(d => d.Key.Name == product.Name).FirstOrDefault();
                KeyValuePair<Product, int> productOld = ListCart.Where(d => d.Key.Name.Equals(product.Name)).FirstOrDefault();
                int total = productOld.Value + quantity;
                ListCart.Remove(productOld);
                ListCart.Add(productOld.Key, total);
            }

            else
            {
                ListCart.Add(product, quantity);
            }
       
        }
        
        public void DeleteItem(Product product)
        {
            KeyValuePair<Product, int> productRemove = ListCart.Where(p => p.Key.Name.Equals(product.Name)).FirstOrDefault();
            ListCart.Remove(productRemove);
        }       
    }
}
