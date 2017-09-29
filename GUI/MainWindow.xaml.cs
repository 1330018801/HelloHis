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

namespace GUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DTO.LoginUser user = new DTO.LoginUser();

        public MainWindow()
        {
            InitializeComponent();
            if (user.Status == DTO.LoginUser.LoginStatus.logout)
            {
                loginBtn.IsEnabled = true;
                logoutBtn.IsEnabled = false;
            }
            else
            {
                loginBtn.IsEnabled = false;
                logoutBtn.IsEnabled = true;
            }
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "")
            {
                loginResult.Text = "Please input username";
                return;
            }
            if (password.Text == "")
            {
                loginResult.Text = "Please input password";
                return;
            }
            loginResult.Text = "Authenticating...";
            
            user.Username = username.Text;
            user.Password = password.Text;

            //BLL.Login login = new BLL.Login(user);
            CommClient.Login login = new CommClient.Login(user.Username, user.Password);
            if (login.Authenticate())
            {
                loginResult.Text = "Login success!";
                user.Status = DTO.LoginUser.LoginStatus.login;
                loginBtn.IsEnabled = false;
                logoutBtn.IsEnabled = true;
            }
            else
            {
                loginResult.Text = "Login failed!";
            }
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (user.Status == DTO.LoginUser.LoginStatus.login)
            {
                //BLL.Login login = new BLL.Login(user);
                CommClient.Login login = new CommClient.Login(user.Username, user.Password);
                if (login.Logout())
                {
                    loginResult.Text = user.Username + " logout success!";
                    user.Status = DTO.LoginUser.LoginStatus.logout;
                    user.Username = "Anonomous";
                    loginBtn.IsEnabled = true;
                    logoutBtn.IsEnabled = false;
                    username.Clear();
                    password.Clear();
                } else
                {
                    loginResult.Text = "Logout failed!";
                }
            }
        }
    }
}
