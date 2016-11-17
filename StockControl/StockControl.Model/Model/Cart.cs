using StockControl.Model.Dao;
using StockControl.Model.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockControl.Model.Model
{
    public class Cart
    {       
        private ProductDao ProductDao { get; set; }
        private SalesDao SalesDao { get; set; }
        private StockDao StockDao { get; set; }


        //|-------------PROPERTIES------------|
        public ObservableDictionary<Product, int> ListCart { get; set; }
        public ObservableCollection<Sales> ProductSold { get; set; }


        //|------------CONSTRUCTOR------------|
        public Cart()
        {
            ProductDao = new ProductDao();
            SalesDao = new SalesDao();
            this.StockDao = new StockDao();
            this.ListCart = new ObservableDictionary<Product, int>();
            this.ProductSold = new ObservableCollection<Sales>();
        }

        //|-------------METHODS--------------|

        public IEnumerable<Product> GetProducts()
        {
            return this.ProductDao.GetProducts();
        }
        /// <summary>       
        /// Adds the product and quantity to the cart. If the product already exists, it is removed and added to the updated value.
        /// </summary>
        /// <param name="product"> Parameter product requires a 'Product' argument</param>
        /// /// <param name="quantity"> Parameter quantity requires an 'int' argument</param>        
        public void ReceiveProduct(Product product, int quantity)
        {
            int quantityInStock = StockDao.GetQuantityOfAProduct(product.ProductId);

            KeyValuePair<Product, int> productOld = ListCart.Where(d => d.Key.Name.Equals(product.Name)).FirstOrDefault();
            int quantityTotal = productOld.Value + quantity;

            if (quantityInStock >= quantityTotal)
            {
                if (ListCart.ContainsKey(product))
                {
                    ListCart.Remove(productOld);
                    ListCart.Add(productOld.Key, quantityTotal);

                }
                else
                {
                    ListCart.Add(product, quantity);
                }

            }
            else
            {
                MessageBox.Show("Quantidade superior a do produto presente no estoque - Quantidade : " + quantityInStock);
            }

        }

        /// <summary>
        /// Show a list of products purchased in a new view or in a ListView
        /// </summary>       
        public void ShowProductsPurchased()
        {
            //TODO: criar tela com as compras realizadas
            this.ProductSold.Clear();
            IEnumerable<Sales> productsSold = SalesDao.GetProductsSold();

            foreach(Sales s in productsSold)
            {
                this.ProductSold.Add(s);
            }
            
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
            Sales sales = new Sales();
            sales.ProductsSold = this.ListCart;
            this.SalesDao.Insert(sales);

            foreach(KeyValuePair<Product,int> p in sales.ProductsSold)
            {
                this.StockDao.Update(new Stock(p.Key,p.Value));
            }

            MessageBox.Show("Produto(s) comprado(s) com sucesso!");
            this.ShowProductsPurchased();
            
        }      
    }
}
