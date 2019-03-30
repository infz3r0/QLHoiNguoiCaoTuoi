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
    /// Interaction logic for Sua.xaml
    /// </summary>
    public partial class Sua : Window
    {
        private KhuPhoDAO khuPhoDAO;
        private KHU_PHO o;

        public Sua(KHU_PHO o)
        {
            InitializeComponent();

            khuPhoDAO = new KhuPhoDAO();

            this.o = o;
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

            o.TEN_KHU_PHO = tenKhuPho;
            try
            {
                khuPhoDAO.Update(o);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txbTenKhuPho.Text = o.TEN_KHU_PHO;
            txbTenKhuPho.Focus();
        }
    }
}
