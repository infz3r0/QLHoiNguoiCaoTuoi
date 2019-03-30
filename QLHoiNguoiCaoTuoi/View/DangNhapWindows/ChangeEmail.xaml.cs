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

namespace QLHoiNguoiCaoTuoi.View.DangNhapWindows
{
    /// <summary>
    /// Interaction logic for ChangeEmail.xaml
    /// </summary>
    public partial class ChangeEmail : Window
    {
        private Auth auth;
        TV_BAN_CHAP_HANH bch;

        public ChangeEmail(TV_BAN_CHAP_HANH bch)
        {
            InitializeComponent();

            auth = new Auth();

            this.bch = bch;            
        }

        private void TxbNewEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            txbNewEmail.SelectAll();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string email = txbNewEmail.Text;

            //test email
            if (TestInput.StringIsNullEmptyWhiteSpace(email) || !TestInput.StringIsEmail(email))
            {
                MessageBox.Show("Email không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbNewEmail.Focus();
                return;
            }

            //change email
            TV_BAN_CHAP_HANH n = bch;
            n.EMAIL = email;
            try
            {
                auth.ChangeEmail(n);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }

            MessageBox.Show("Thay đổi thành công", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            Close();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTitle.Content = "Đổi Email";

            txbCurrentEmail.Text = bch.EMAIL;
            txbNewEmail.Text = string.Empty;

            txbNewEmail.Focus();
        }
    }
}
