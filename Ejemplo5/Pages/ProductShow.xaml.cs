using Ejemplo5.UsersClass;
using Ejemplo5.XML;
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

namespace Ejemplo5.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductShow.xaml
    /// </summary>
    public partial class ProductShow : Page
    {
        public productoHandler ProductoHandler;
        public Producto producto;
        public int pos;
        public ProductShow(productoHandler productoHandler)
        {
            InitializeComponent();
            this.ProductoHandler = productoHandler;
            comboProduct.DataContext = productoHandler;
            pos = comboProduct.SelectedIndex;
            buttonsPanel.Visibility = Visibility.Hidden;
        }

        private void comboProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            producto = (Producto)comboProduct.SelectedItem;
            ProductoDataGrid.DataContext = producto;
            pos = comboProduct.SelectedIndex;
            buttonsPanel.Visibility = Visibility.Visible;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Class1.editarProducto(producto);
            MainWindow.myNavigationFrame.NavigationService.Navigate(new ProductNewOrModify("Modificar usuario", ProductoHandler, (Producto)producto.Clone(), pos));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // ProductoHandler.Removeproduct(pos);
            Class1.RemoveProducto(producto.precio);
            MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
        }
    }
}
