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
using QLHoiNguoiCaoTuoi.View;
using QLHoiNguoiCaoTuoi.View.DangNhapWindows;

namespace QLHoiNguoiCaoTuoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool spnAccount_isMouseDown;
        private bool logout;
        private TV_BAN_CHAP_HANH bch;

        private void GetAccount(string username)
        {
            using (Entities db = new Entities())
            {
                bch = db.TV_BAN_CHAP_HANH.FirstOrDefault(x => x.USERNAME.Equals(username));
            }
        }

        private void LoadInfoAccount()
        {
            if (bch != null)
            {
                lblUsername.Content = bch.USERNAME;
                lblEmail.Content = bch.EMAIL;
            }
        }

        public MainWindow(string username)
        {
            InitializeComponent();

            logout = false;

            GetAccount(username);
        }

        private void spnAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            spnAccount_isMouseDown = true;
        }

        private void spnAccount_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (spnAccount_isMouseDown)
            {
                spnAccount.ContextMenu.IsEnabled = true;
                spnAccount.ContextMenu.IsOpen = true;
                spnAccount.ContextMenu.PlacementTarget = spnAccount;
                spnAccount.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
                spnAccount.ContextMenu.VerticalOffset = spnAccount.ActualHeight;
                spnAccount.ContextMenu.HorizontalOffset = spnAccount.ActualWidth - spnAccount.ContextMenu.ActualWidth;
                
                spnAccount_isMouseDown = false;
            }
        }

        private void BtnQLKhuPho_Click(object sender, RoutedEventArgs e)
        {
            QLKhuPho w = new QLKhuPho();
            w.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadInfoAccount();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!logout)
            {
                Exit();
            }
            
        }

        private void Logout()
        {
            logout = true;
            //DangNhap window
            DangNhap w = (DangNhap)this.Owner;
            w.Show();
            w.Activate();
            w.InitForm();
            this.Close();
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        private void MnuLogout_Click(object sender, RoutedEventArgs e)
        {
            Logout();
        }

        private void MnuExit_Click(object sender, RoutedEventArgs e)
        {
            Exit();
        }

        private void MnuChangeEmail_Click(object sender, RoutedEventArgs e)
        {
            ChangeEmail w = new ChangeEmail(bch);
            w.Owner = this;
            w.ShowDialog();
            //Reload account info
            GetAccount(bch.USERNAME);
            LoadInfoAccount();

        }

        private void MnuChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword w = new ChangePassword(bch);
            w.Owner = this;
            w.ShowDialog();
        }



        //end
    }
}
