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

namespace QLHoiNguoiCaoTuoi.View.ChucVuWindows
{
    /// <summary>
    /// Interaction logic for Sua.xaml
    /// </summary>
    public partial class Sua : Window
    {
        private ChucVuDAO chucVuDAO;
        private CHUC_VU cv;

        public Sua(CHUC_VU cv)
        {
            InitializeComponent();

            chucVuDAO = new ChucVuDAO();
            this.cv = cv;
        }

        private void TxbHeSoLuong_GotFocus(object sender, RoutedEventArgs e)
        {
            txbHeSoLuong.SelectAll();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string shesoluong = txbHeSoLuong.Text;
            decimal hesoluong;
            bool isvalid = decimal.TryParse(shesoluong, out hesoluong);
            if (!isvalid)
            {
                MessageBox.Show("Hệ số lương không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbHeSoLuong.Focus();
                return;
            }

            try
            {
                cv.HE_SO_LUONG = hesoluong;
                chucVuDAO.Update(cv);
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txbTenChucVu.Text = cv.TEN_CHUC_VU;
            txbHeSoLuong.Text = cv.HE_SO_LUONG.ToString();
            txbHeSoLuong.Focus();
        }
    }
}
