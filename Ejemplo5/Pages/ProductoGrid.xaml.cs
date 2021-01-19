using Ejemplo5.UsersClass;
using Ejemplo5.XML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;

namespace Ejemplo5.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductoGrid.xaml
    /// </summary>
   
    public partial class ProductoGrid : Page
    {

        productoHandler ProductoHandler;
        private XDocument xml = XDocument.Load("../../XML/XMLFile1.xml");
        private ObservableCollection<Producto> listaFiltrada;

        public ProductoGrid(productoHandler productHandler)
        {
            InitializeComponent();
            this.ProductoHandler = productHandler;
            UpdateProductList();
            InitCategoryCombo();

        }

        public ProductoGrid()
        {
        }

        private void InitCategoryCombo()
        {
            categoryCombo.Items.Add("Todas ...");
            var listaCategoriasXML = xml.Root.Elements("tipo").Attributes("idTipo");

            foreach (XAttribute categoriaXML in listaCategoriasXML)
            {

                categoryCombo.Items.Add(categoriaXML.Value);
            }
            categoryCombo.SelectedIndex = 0;
        }

        private void UpdateProductList()
        {

            categoryCombo.SelectedIndex = 0;
            busquedaTextBox.Text = "";
            listaFiltrada = new ObservableCollection<Producto>(ProductoHandler.ProductList);
            myDataGrid.ItemsSource = ProductoHandler.ProductList ;
            myDataGrid.DataContext = ProductoHandler.ProductList;
            myDataGrid.Items.Refresh();
        }

        private void categoryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (categoryCombo.SelectedIndex == 0)
            {

                UpdateProductList();

            }
            else
            {

                listaFiltrada.Clear();


                foreach (Producto product in ProductoHandler.ProductList)
                {

                    if (product.tipo.Equals((string)categoryCombo.SelectedItem))
                    {

                        listaFiltrada.Add(product);
                    }
                }

                myDataGrid.ItemsSource = listaFiltrada;
                myDataGrid.DataContext = listaFiltrada;
                myDataGrid.Items.Refresh();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<Producto> nuevaListaFiltrada = new ObservableCollection<Producto>();
            foreach (Producto product in listaFiltrada)
            {

                if (product.GetAllValues().Contains(busquedaTextBox.Text))
                {

                    nuevaListaFiltrada.Add(product);

                }
            }
            myDataGrid.ItemsSource = nuevaListaFiltrada;
            myDataGrid.DataContext = nuevaListaFiltrada;
            myDataGrid.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateProductList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Producto product = (Producto)myDataGrid.SelectedItem;
            MainWindow.myNavigationFrame.NavigationService.Navigate(new ProductNewOrModify("Modificar usuario", ProductoHandler));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Producto product = (Producto)myDataGrid.SelectedItem;
            Class1.RemoveProducto(product.precio);
            UpdateProductList();
        }
    }
}
