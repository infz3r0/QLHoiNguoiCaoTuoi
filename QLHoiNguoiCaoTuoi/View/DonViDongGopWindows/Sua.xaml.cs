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

namespace QLHoiNguoiCaoTuoi.View.DonViDongGopWindows
{
    /// <summary>
    /// Interaction logic for Sua.xaml
    /// </summary>
    public partial class Sua : Window
    {
        private DonViDongGopDAO dvDAO;
        private DON_VI_DONG_GOP dv;

        public Sua(DON_VI_DONG_GOP dv)
        {
            InitializeComponent();

            dvDAO = new DonViDongGopDAO();

            this.dv = dv;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txbTenDonVi.Text = dv.TEN_DON_VI;
            txbDiaChi.Text = dv.DIA_CHI;
            txbEmail.Text = dv.EMAIL;
            txbTenDonVi.Focus();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string ten = txbTenDonVi.Text;
            string diachi = txbDiaChi.Text;
            string email = txbEmail.Text;

            if (ten.Length > 50 || TestInput.StringIsNullEmptyWhiteSpace(ten))
            {
                MessageBox.Show("Tên không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTenDonVi.Focus();
                return;
            }

            if (diachi.Length > 200 || TestInput.StringIsNullEmptyWhiteSpace(diachi))
            {
                MessageBox.Show("Địa chỉ không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbDiaChi.Focus();
                return;
            }

            if (email.Length > 100 || TestInput.StringIsNullEmptyWhiteSpace(email) || !TestInput.StringIsEmail(email))
            {
                MessageBox.Show("Email không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbEmail.Focus();
                return;
            }

            try
            {
                dv.TEN_DON_VI = ten;
                dv.DIA_CHI = diachi;
                dv.EMAIL = email;

                dvDAO.Update(dv);
            }
            catch (Exception ex)
            {
                MessageUtliity.ShowException(ex);
                return;
            }

            MessageUtliity.ShowUpdateSuccess();
            Close();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TxbTenDonVi_GotFocus(object sender, RoutedEventArgs e)
        {
            txbTenDonVi.SelectAll();
        }

        private void TxbDiaChi_GotFocus(object sender, RoutedEventArgs e)
        {
            txbDiaChi.SelectAll();
        }

        private void TxbEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            txbEmail.SelectAll();
        }
    }
}
