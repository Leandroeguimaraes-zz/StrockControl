using StockControl.Model.Dao;
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
        private ProductDao productDao = new ProductDao();
        private SalesDao salesDao = new SalesDao();

        //|-------------PROPERTIES------------|
        public ObservableDictionary<Product, int> ListCart { get; set; }


        //|------------CONSTRUCTOR------------|
        public Cart()
        {           
            this.ListCart = new ObservableDictionary<Product, int>();
        }

        //|-------------METHODS--------------|

        public IEnumerable<Product> GetProducts()
        {
            return this.productDao.GetProducts();
        }
        /// <summary>       
        /// Adds the product and quantity to the cart. If the product already exists, it is removed and added to the updated value.
        /// </summary>
        /// <param name="product"> Parameter product requires a 'Product' argument</param>
        /// /// <param name="quantity"> Parameter quantity requires an 'int' argument</param>        
        public void ReceiveProduct(Product product, int quantity)
        {
            if (ListCart.ContainsKey(product))
            {               
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

        /// <summary>
        /// Show a list of products purchased in a new view or in a ListView
        /// </summary>       
        public void ShowProductsPurchased()
        {
            //TODO: criar tela com as compras realizadas
            
        }

        /// <summary>
        /// The product selected in the cart is deleted.
        /// </summary>
        /// <param name="product"> Parameter product requires a 'Product' argument</param>                
        public void DeleteProductSelected(Product product)
        {
            KeyValuePair<Product, int> productRemove = ListCart.Where(p => p.Key.Name.Equals(product.Name)).FirstOrDefault();
            ListCart.Remove(productRemove);
        }

        /// <summary>
        /// Clean the entire product list  
        /// </summary>              
        public void Clear()
        {
            this.ListCart.Clear();
        }

        /// <summary>
        /// All products in the cart are saved and updated in the database
        /// </summary>        
        public void BuyProducts()
        {
            //TODO: Salvar e atulaizar no Dao.
          
            Sales sales = new Sales();
            sales.ProductsSold = this.ListCart;
            this.salesDao.InsertOrUpdate(sales);           
        }      
    }
}
