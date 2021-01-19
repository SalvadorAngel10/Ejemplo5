using Ejemplo5.Pages;
using Ejemplo5.UsersClass;
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

namespace Ejemplo5
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public static Frame myNavigationFrame;
        public UsersHandler usersHandler;
        public productoHandler ProductoHandler;
        public MainWindow()
        {
            InitializeComponent();
            myNavigationFrame = myFrame;
            usersHandler = new UsersHandler();
            ProductoHandler = new productoHandler();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new MainPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new NewOrModifyUserPage("NUEVO TRAFICANTE", usersHandler));
        }
       

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new ShowUserPage(usersHandler));

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new MainPage());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new ProductNewOrModify("NUEVO ARMA",ProductoHandler));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ProductoHandler.Actualizarxml();
            myNavigationFrame.NavigationService.Navigate(new ProductShow(ProductoHandler));
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (trafi.IsVisible)
            {
                trafi.Visibility = Visibility.Hidden;
            }
            else { trafi.Visibility = Visibility.Visible; }
            
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (arma.IsVisible)
            {
                arma.Visibility = Visibility.Hidden;
            }
            else { arma.Visibility = Visibility.Visible; }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            //myNavigationFrame.NavigationService.Navigate(new Window1());
            Window1 window1 = new Window1();
            window1.Show();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            myNavigationFrame.NavigationService.Navigate(new ProductoGrid(ProductoHandler));
        }
    }
}
