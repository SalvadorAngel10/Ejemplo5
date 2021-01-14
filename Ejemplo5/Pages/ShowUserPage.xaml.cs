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
    /// Lógica de interacción para ShowUserPage.xaml
    /// </summary>
    public partial class ShowUserPage : Page
    {
        public UsersHandler usersHandler;
        public User user;
        public int pos;
        public ShowUserPage(UsersHandler usersHandler)
        {
            InitializeComponent();
            this.usersHandler = usersHandler;
            comboUsers.DataContext = usersHandler;
            pos = comboUsers.SelectedIndex;
            buttonsPanel.Visibility = Visibility.Hidden;
        }

        private void comboUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            user = (User)comboUsers.SelectedItem;
            userDataGrid.DataContext = user;
            pos = comboUsers.SelectedIndex;
            buttonsPanel.Visibility = Visibility.Visible;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.myNavigationFrame.NavigationService.Navigate(new NewOrModifyUserPage("Modificar usuario", usersHandler,(User) user.Clone(), pos));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            usersHandler.RemoveUser(pos);
            MainWindow.myNavigationFrame.NavigationService.Navigate(new MainPage());
        }
    }
}
