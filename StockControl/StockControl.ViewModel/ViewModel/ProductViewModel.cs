using GalaSoft.MvvmLight.Command;
using StockControl.Model.Domain;
using StockControl.Model.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.ViewModel.ViewModel
{
    public class ProductViewModel
    {

        Cart cart;

        public ProductViewModel()
        {
            cart = new Cart();
            this.ProductSelected = new KeyValuePair<Product, int>();
              
        }
        public Product Product { get; set; }      
        public int Quantity { get; set; }

        KeyValuePair<Product,int> ProductSelected { get; set; }

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
        public RelayCommand DeleteItemCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    this.cart.DeleteItem(ProductSelected.Key);
                });
            }
        }

        
    }
}
