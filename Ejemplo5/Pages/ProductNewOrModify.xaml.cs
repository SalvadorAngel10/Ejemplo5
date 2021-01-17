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
using System.Xml.Linq;

namespace Ejemplo5.Pages
{
    /// <summary>
    /// Lógica de interacción para ProductNewOrModify.xaml
    /// </summary>
    public partial class ProductNewOrModify : Page
    {
        private XDocument xml = XDocument.Load("../../XML/XMLFile1.xml");
        public productoHandler productoHandler ;
        public Producto producto;
        public int pos;
        public bool verify;

        public ProductNewOrModify(productoHandler productoHandler)
        {
            this.productoHandler = productoHandler;
        }
        private bool Validation()
        {

            bool validate = true;

            foreach (UIElement element in productGrid.Children)
            {

                if (element is TextBox)
                {
                    TextBox textBox = (TextBox)element;

                    if (textBox.Text.Equals(""))
                    {
                        textBox.BorderBrush = new SolidColorBrush(Colors.Red);
                        validate = false;
                    }
                    else
                    {
                        textBox.BorderBrush = new SolidColorBrush(Colors.LightGray);
                    }
                }

            }

            return validate;
        } //validacion
        //constructor de nuevo
        public ProductNewOrModify(string title, productoHandler productoHandler)
        {
            InitializeComponent();
            Combo();
            productoNM.Text = title;
            this.productoHandler = productoHandler;
            this.verify = false;
            producto = new Producto();
            this.productGrid.DataContext = producto;
        }

        //constructor de modificar
        public ProductNewOrModify(string title, productoHandler productoHandler, Producto producto, int pos)
        {
            InitializeComponent();
            Combo();
            productoNM.Text = title;
            this.productoHandler = productoHandler;
            this.producto = producto;
            this.pos = pos;
            this.productGrid.DataContext = producto;
            this.verify = true;

        }

        private void Combo() 
        {
            var listaProductos = xml.Root.Elements("tipo").Attributes("idTipo");

            for(int i = 0; i < listaProductos.Count(); i++) 
            {
                txt_tipo.Items.Add(listaProductos.ElementAt(i).Value);
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (verify)
            {
                productoHandler.Modifyproduct(producto, pos);
                MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());

            }
            else
            {
               
                String tipo = txt_tipo.Text;

                String marca = txt_modelo.Text;
                String precio = txt_precio.Text;
                String stock = txt_stock.Text;
                DateTime fechaAlta = (DateTime)txt_fechaAlta.SelectedDate;
                /*Class1.LoadXMl();
                Class1.AddCategoria("coches");
                 Class1.saveXML();*/

               
                if (Validation())
                {
                    MessageBoxResult resultado = MessageBox.Show("Tipo: "+tipo + "\n" +
                    "Marca: " + marca  + "\n" +
                    "Precio:" + precio + "\n" +
                    "Stock: " + stock + "\n" +
                    "Fecha de alta: " + fechaAlta + "\n\n" +
                    "¿ESTOS DATOS SON CORRECTOS?",
                    "registro usuarios",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Question);

                    switch (resultado)
                    {
                        case MessageBoxResult.Yes:
                            MessageBox.Show("se ha refistrado bien");
                            Producto producto = new Producto(tipo, marca, precio, stock, fechaAlta);
                            productoHandler.Addproduct(producto);
                            MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
                            //MostrarUsuario mostrarUsuario = new MostrarUsuario(usuario);
                            //mostrarUsuario.Show();
                            break;
                        case MessageBoxResult.No:
                            break;
                        case MessageBoxResult.Cancel:
                            break;

                    }
                    /* Producto producto = new Producto(tipo, marca, precio, stock, fechaAlta);
                     productoHandler.Addproduct(producto);
                     MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
                     */
                }
                else { label.Content = "INTRODUZCA BIEN LA INFORMACION DEL PRODUCTO";
                    label.Visibility = Visibility.Visible;
                        }
            }
        }

        private void txt_tipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_modelo.Items.Clear();
            var modeloList = xml.Root.Elements("tipo").ElementAt(txt_tipo.SelectedIndex).Elements().Attributes("nombre");

            for (int i = 0; i < modeloList.Count(); i++) 
            {
                txt_modelo.Items.Add(modeloList.ElementAt(i).Value);
            }
        }

        private void cMarca_Click(object sender, RoutedEventArgs e)
        {
            if (txt_modelo.IsVisible)
            {
           
                txt_modelo.Visibility = Visibility.Hidden;
                
            }
            else
            {
             
                txt_modelo.Visibility = Visibility.Visible;
             
            }
        }

        private void cTipo_Click(object sender, RoutedEventArgs e)
        {
            if (txt_tipo.IsVisible)
            {
                txt_tipo.Visibility = Visibility.Hidden;
                txt_modelo.Visibility = Visibility.Hidden;
                cMarca.IsEnabled = true;
            }
            else 
            {
                txt_tipo.Visibility = Visibility.Visible;
                txt_modelo.Visibility = Visibility.Visible;
                cMarca.IsEnabled = false;
            }
        }

        private void cTipo_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cMarca_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
