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

namespace Ejemplo5.Pages
{
    /// <summary>
    /// Lógica de interacción para NewOrModifyUserPage.xaml
    /// </summary>


    
    public partial class NewOrModifyUserPage : Page
    {
        public UsersHandler usersHandler;
        public User user;
        public int pos;
        public bool verify;

        //constructor de nuevo
        public NewOrModifyUserPage(string title, UsersHandler usersHandler)
        {
            InitializeComponent();
            titleNewOrModify.Text = title;
            this.usersHandler = usersHandler;
            this.verify = false;
            user =new User();
            this.userGrid.DataContext = user;
        }

        //constructor de modificar
        public NewOrModifyUserPage(string title, UsersHandler usersHandler, User user, int pos)
        {
            InitializeComponent();
            titleNewOrModify.Text = title;
            this.usersHandler = usersHandler;
            this.user = user;
            this.pos = pos;
            this.userGrid.DataContext = user;
            this.verify = true;

        }
        private bool Validation()
        {

            bool validate = true;

            foreach (UIElement element in userGrid.Children)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (verify)
            {
                usersHandler.ModifyUser(user,pos);
                MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());

            }
            else
            {

                String nombre = txt_Nombre.Text;
                String telefono = txt_Telefono.Text;
                DateTime fechaAlta = (DateTime)txt_fechaAlta.SelectedDate;

                if (Validation())
                {

                    MessageBoxResult resultado = MessageBox.Show("Nombre :" + nombre+ "\n" +
                   "Telefono: " + telefono + "\n" +
                   "Fecha de alta: " + fechaAlta + "\n" +
                   "¿ESTOS DATOS SON CORRECTOS?",
                   "registro usuarios",
                   MessageBoxButton.YesNoCancel,
                   MessageBoxImage.Question);

                    switch (resultado)
                    {
                        case MessageBoxResult.Yes:
                            MessageBox.Show("se ha refistrado bien");
                            User user = new User(nombre, telefono, fechaAlta);
                            usersHandler.AddUser(user);
                            MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
                            //MostrarUsuario mostrarUsuario = new MostrarUsuario(usuario);
                            //mostrarUsuario.Show();
                            break;
                        case MessageBoxResult.No:
                            break;
                        case MessageBoxResult.Cancel:
                            break;

                    }
                    /*User user = new User(nombre, telefono, fechaAlta);
                    usersHandler.AddUser(user);
                    MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
                    */
                }
                else {
                    label.Content = "INTRODUCE LOS DATOS CORRECTAMENTE";
                }
            }

          

        }
    }
}
