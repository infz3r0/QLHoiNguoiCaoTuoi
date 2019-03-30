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
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        private Auth auth;
        private TV_BAN_CHAP_HANH bch;
        private SolidColorBrush brushRed, brushGreen;

        public ChangePassword(TV_BAN_CHAP_HANH bch)
        {
            InitializeComponent();

            auth = new Auth();

            this.bch = bch;

            brushRed = new SolidColorBrush(Color.FromRgb(255, 209, 209));
            brushGreen = new SolidColorBrush(Color.FromRgb(176, 251, 169));
        }

        private void TxbCurrentPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            pwdCurrentPassword.SelectAll();
        }

        private void TxbNewPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            pwdNewPassword.SelectAll();
        }

        private void TxbRePassword_GotFocus(object sender, RoutedEventArgs e)
        {
            pwdRePassword.SelectAll();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string currentPassword = pwdCurrentPassword.Password;
            string newPassword = pwdNewPassword.Password;
            string rePassword = pwdRePassword.Password;

            //test current password
            if (TestInput.StringIsNullEmptyWhiteSpace(currentPassword))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                pwdCurrentPassword.Focus();
                return;
            }

            if (!MD5Cal.VerifyMd5Hash(currentPassword, bch.PASSWORD))
            {
                MessageBox.Show("Sai password", "Wrong password", MessageBoxButton.OK, MessageBoxImage.Warning);
                pwdCurrentPassword.Focus();
                return;
            }

            //test new password
            if (TestInput.StringIsNullEmptyWhiteSpace(newPassword))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                pwdNewPassword.Focus();
                return;
            }

            if (TestInput.StringIsNullEmptyWhiteSpace(rePassword))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                pwdRePassword.Focus();
                return;
            }

            if (!newPassword.Equals(rePassword))
            {
                MessageBox.Show("Password không trùng khớp", "Password not match", MessageBoxButton.OK, MessageBoxImage.Warning);
                pwdNewPassword.Focus();
                return;
            }

            //change password
            TV_BAN_CHAP_HANH n = bch;
            n.PASSWORD = MD5Cal.GetMd5Hash(newPassword);
            try
            {
                auth.ChangePassword(n);
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
            lblTitle.Content = "Đổi Password";

            pwdCurrentPassword.Password = string.Empty;
            pwdNewPassword.Password = string.Empty;
            pwdRePassword.Password = string.Empty;
            pwdCurrentPassword.Focus();
        }

        private void TestPasswordEffect()
        {
            string newpassword = pwdNewPassword.Password;
            string repassword = pwdRePassword.Password;

            if (!TestInput.StringIsNullEmptyWhiteSpace(newpassword) || !TestInput.StringIsNullEmptyWhiteSpace(repassword))
            {
                if (!newpassword.Equals(repassword))
                {
                    pwdNewPassword.Background = brushRed;
                    pwdRePassword.Background = brushRed;
                }
                else
                {
                    pwdNewPassword.Background = brushGreen;
                    pwdRePassword.Background = brushGreen;
                }
            }
            else
            {
                pwdNewPassword.Background = Brushes.White;
                pwdRePassword.Background = Brushes.White;
            }
        }

        private void PwdNewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TestPasswordEffect();
        }

        private void PwdRePassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TestPasswordEffect();
        }
    }
}
