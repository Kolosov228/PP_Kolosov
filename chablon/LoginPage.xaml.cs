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

namespace chablon
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string LoginTxt = TxbLogin.Text.ToLower();
            string PasswordTxt = TxbPassword.Text.ToLower();

            if (LoginTxt == "admin" && PasswordTxt == "admin" )
            {
                NavigationService.Navigate(new InfMain());
            }
            else
            {
                MessageBox.Show("Неверный пользователь");
            }

            if (LoginTxt == "employeer" && PasswordTxt == "employeer")
            {
                NavigationService.Navigate(new InfMainEmp());
            }
            else
            {
                MessageBox.Show("Неверный пользователь");
            }

        }
    }
}
