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
using System.Windows.Shapes;
using QLHoiNguoiCaoTuoi.Utility;

namespace QLHoiNguoiCaoTuoi.View
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        private Auth auth;
        private Test test;
        private bool loggedin;
        private bool connected;

        private async void TestConnection()
        {
            test = new Test();
            Task<bool> task = test.DBConnected();
            //Start loading animation
            pgbLoading.IsIndeterminate = true;
            //wait for task complete
            connected = await task;
            //Stop animation
            pgbLoading.IsIndeterminate = false;

            if (connected)
            {
                EnableControls();
                txbUsername.Focus();
            }
            else
            {
                MessageBox.Show("Can't connect to database. Restart application.", "Connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _Dispatch(Action action)
        {
            if (Dispatcher.CheckAccess())
                action();
            else
                Dispatcher.Invoke(action);
        }

        public void InitForm()
        {
            loggedin = false;
            txbUsername.Text = string.Empty;
            txbPassword.Password = string.Empty;

            DisableControls();
            //Test connection to DB
            TestConnection();
        }

        public DangNhap()
        {
            InitializeComponent();

            lblTitle.Content = "Đăng nhập";
            InitForm();

            auth = new Auth();
        }

        private void EnableControls()
        {
            txbUsername.IsEnabled = true;
            txbPassword.IsEnabled = true;
            btnLogin.IsEnabled = true;
            btnExit.IsEnabled = true;
        }

        private void DisableControls()
        {
            txbUsername.IsEnabled = false;
            txbPassword.IsEnabled = false;
            btnLogin.IsEnabled = false;
            btnExit.IsEnabled = false;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DisableControls();
            //username
            if (TestInput.StringIsNullEmptyWhiteSpace(txbUsername.Text))
            {
                MessageBox.Show("Username không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbUsername.Focus();
                return;
            }

            //password
            if (TestInput.StringIsNullEmptyWhiteSpace(txbPassword.Password))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbPassword.Focus();
                return;
            }


            bool loggedin = auth.Login(txbUsername.Text, MD5Cal.GetMd5Hash(txbPassword.Password));

            EnableControls();

            if (loggedin)
            {
                //MessageBox.Show("Success");
                MainWindow w = new MainWindow(txbUsername.Text);
                w.Owner = this;
                w.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai username hoặc password", "Login failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbUsername.Focus();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!loggedin)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void TxbUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txbUsername.SelectAll();
        }

        private void TxbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txbPassword.SelectAll();
        }



        //end class
    }
}
