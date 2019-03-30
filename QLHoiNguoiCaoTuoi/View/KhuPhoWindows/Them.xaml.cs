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

namespace QLHoiNguoiCaoTuoi.View.KhuPhoWindows
{
    /// <summary>
    /// Interaction logic for Them.xaml
    /// </summary>
    public partial class Them : Window
    {
        private KhuPhoDAO khuPhoDAO;
        public Them()
        {
            InitializeComponent();

            khuPhoDAO = new KhuPhoDAO();
        }

        private void TxbTenKhuPho_GotFocus(object sender, RoutedEventArgs e)
        {
            txbTenKhuPho.SelectAll();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string tenKhuPho = txbTenKhuPho.Text;
            if (tenKhuPho.Length > 30 || TestInput.StringIsNullEmptyWhiteSpace(tenKhuPho))
            {
                MessageBox.Show("Tên khu phố không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTenKhuPho.Focus();
                return;
            }

            KHU_PHO n = new KHU_PHO();
            n.TEN_KHU_PHO = tenKhuPho;
            try
            {
                khuPhoDAO.Insert(n);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            txbTenKhuPho.Clear();
            txbTenKhuPho.Focus();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txbTenKhuPho.Focus();
        }
    }
}
