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
        //---------Variables--------|

        private Cart cart;
      


        //--------Constructor--------|

        public ProductViewModel()
        {
            cart = new Cart();
            this.ProductSelected = new KeyValuePair<Product, int>();
              
        }

        //---------Properties----------|

        public Product Product { get; set; }      
        public int Quantity { get; set; }

        public KeyValuePair<Product,int> ProductSelected { get; set; }

        public ObservableDictionary<Product, int> ListCart {
            get
            {
                return this.cart.ListCart;
            }
            set
            {
                this.cart.ListCart = value;                
            }
        }

        //|----------Commands----------|

        /// <summary>
        ///  Sends the product and quantity to the cart
        /// </summary>
        /// <returns>The method returns a RelayCommand</returns>           
        public RelayCommand SendToCartCommand
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {                                               
                        this.cart.ReceiveProduct(Product, Quantity);
                    });
            }
        }


        /// <summary>
        /// Sends to the  model to show a list of products purchased     
        /// </summary>       
        /// <returns>The method returns a RelayCommand</returns>
        public RelayCommand ViewList
        {
            get
            {
                return new RelayCommand(() => 
                {
                    this.cart.ShowProductsPurchased();
                });
            }
        }


        /// <summary>
        /// Sends to the  model to delete a selected product in the cart 
        /// </summary>       
        /// <returns>The method returns a RelayCommand</returns>
        public RelayCommand DeleteProductCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                   
                    this.cart.DeleteProductSelected(ProductSelected.Key);
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
                    this.cart.Clear();
                });
            }
        }


        /// <summary>
        /// Sends to the  model to buy all products added to the cart        
        /// </summary>       
        /// <returns>The method returns a RelayCommand</returns>
        public RelayCommand BuyCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    this.cart.BuyProducts();
                });
            }
        }
        
    }
}
