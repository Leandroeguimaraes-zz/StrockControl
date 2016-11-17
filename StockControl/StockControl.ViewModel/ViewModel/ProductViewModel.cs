using GalaSoft.MvvmLight.Command;
using StockControl.Model.Domain;
using StockControl.Model.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.ViewModel.ViewModel
{
    public class ProductViewModel 
    {               
        //|--------CONSTRUCTOR--------|

        public ProductViewModel()
        {
            Cart = new Cart();
            this.ProductSelected = new KeyValuePair<Product, int>();
            this.ProductsAvailables = new List<Product>();              
        }

        //|---------PROPERTIES----------|

        public Cart Cart { get; set; }
        public Product Product { get; set; }      
        public int Quantity { get; set; }
        
        public IEnumerable<Product> ProductsAvailables
        {
            get
            {
                return this.Cart.GetProducts();
            }
            set { }
        }
        
        public KeyValuePair<Product,int> ProductSelected { get; set; }
       
        public ObservableDictionary<Product, int> ListCart {
            get
            {
                return this.Cart.ListCart;
            }
            set
            {
                this.Cart.ListCart = value;                
            }
        }

        public ObservableCollection<Sales> ProductsSold {
            get
            {
                return this.Cart.ProductSold;
            }
            set
            {
                this.Cart.ProductSold = value;
            }
        }

        //|----------COMMANDS----------|

        /// <summary>
        ///  Sends the product and quantity to the Cart
        /// </summary>
        /// <returns>The method returns a RelayCommand</returns>           
        public RelayCommand SendToCartCommand
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {                                               
                        this.Cart.ReceiveProduct(Product, Quantity);
                    });
            }
        }

        /// <summary>
        /// Sends to the  model to show a list of products purchased     
        /// </summary>       
        /// <returns>The method returns a RelayCommand</returns>
        public RelayCommand ViewListCommand
        {
            get
            {
                return new RelayCommand(() => 
                {
                    this.Cart.ShowProductsPurchased();
                });
            }
        }

        /// <summary>
        /// Sends to the  model to delete a selected product in the Cart 
        /// </summary>       
        /// <returns>The method returns a RelayCommand</returns>
        public RelayCommand DeleteProductCommand
        {
            get
            {
                return new RelayCommand(() =>
                {                   
                    this.Cart.DeleteProductSelected(ProductSelected.Key);
                });
            }
        }

        /// <summary>
        /// Sends to the  model to clean the entire product list        
        /// </summary>       
        /// <returns>The method returns a RelayCommand</returns>
        public RelayCommand ClearCommand {
            get
            {
                return new RelayCommand(() =>
                {
                    this.Cart.Clear();
                });
            }
        }

        /// <summary>
        /// Sends to the  model to buy all products added to the Cart        
        /// </summary>       
        /// <returns>The method returns a RelayCommand</returns>
        public RelayCommand BuyCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    this.Cart.BuyProducts();
                });
            }
        }
    }
}
