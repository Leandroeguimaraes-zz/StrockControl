using StockControl.Model.Domain;
using StockControl.Model.Model;
using StockControl.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StockControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new ProductViewModel();
                      
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //this.initialize();
            
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void initialize()
        {
            this.uxCbbxProduct.Items.Add(new Product("Product1", 20));
            this.uxCbbxProduct.Items.Add(new Product("Product2", 30));
            this.uxCbbxProduct.Items.Add(new Product("Product3", 40));
            this.uxCbbxProduct.Items.Add(new Product("Product4", 50));
         
        }


    }
}
