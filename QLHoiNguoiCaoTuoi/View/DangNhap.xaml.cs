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

namespace QLHoiNguoiCaoTuoi.View
{
    /// <summary>
    /// Interaction logic for DangNhap.xaml
    /// </summary>
    public partial class DangNhap : Window
    {
        //private TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        private bool loggedin;

        public DangNhap()
        {
            InitializeComponent();

            lblTitle.Content = "Đăng nhập";
            loggedin = false;

            txbUsername.Focus();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //username
            if (string.IsNullOrEmpty(txbUsername.Text) || string.IsNullOrWhiteSpace(txbUsername.Text))
            {
                MessageBox.Show("Username không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbUsername.Focus();
                return;
            }

            //password
            if (string.IsNullOrEmpty(txbPassword.Password) || string.IsNullOrWhiteSpace(txbPassword.Password))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbPassword.Focus();
                return;
            }

            //tai_khoan o = taiKhoanDAO.Login(txbUsername.Text, txbPassword.Password);

            //if (txbUsername.Text.Equals("#Admin") && txbPassword.Password.Equals("!Admin"))
            //{
            //    o = new tai_khoan()
            //    {
            //        id_thanh_vien = -1,
            //        quyen = new quyen()
            //        {
            //            id_quyen = -1,
            //            mo_ta = "#Admin"
            //        },
            //        id_quyen = -1,
            //        username = "#Admin"
            //    };
            //}

            //if (o == null)
            //{
            //    MessageBox.Show("Sai thông tin đăng nhập", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //    txbPassword.Clear();
            //    txbPassword.Focus();
            //    return;
            //}
            //else
            //{
            //    loggedin = true;
            //    //MessageBox.Show("Success", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

            //    MainWindow win = (MainWindow)Application.Current.MainWindow;
            //    win.lblUsername.Content = o.username;
            //    win.id_account = o.id_thanh_vien;
            //    win.id_role = o.id_quyen;
            //    Close();
            //}

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



        //end class
    }
}
