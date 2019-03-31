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

namespace QLHoiNguoiCaoTuoi.View.CLBWindows
{
    /// <summary>
    /// Interaction logic for Sua.xaml
    /// </summary>
    public partial class Sua : Window
    {
        private CLBDAO clbDAO;
        private CLB o;

        public Sua(CLB o)
        {
            InitializeComponent();

            clbDAO = new CLBDAO();

            this.o = o;
        }

        private void LoadDefaultData()
        {
            //Quan ly
            System.Collections.IEnumerable tvs = null;
            using (Entities db = new Entities())
            {
                tvs = db.THANH_VIEN.Select(x => new { HOTEN = x.HO + " " + x.TEN, x.MA_THANH_VIEN }).ToList();
            }
            cmbQuanLy.DisplayMemberPath = "HOTEN";
            cmbQuanLy.SelectedValuePath = "MA_THANH_VIEN";
            cmbQuanLy.ItemsSource = tvs;
            cmbQuanLy.SelectedIndex = 0;

            txbTenCLB.Text = o.TEN_CLB;
            cmbQuanLy.SelectedValue = o.MA_QUAN_LY;
        }

        private void TxbTenCLB_GotFocus(object sender, RoutedEventArgs e)
        {
            txbTenCLB.SelectAll();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDefaultData();
            txbTenCLB.Focus();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string tenclb = txbTenCLB.Text;
            int maquanly = Convert.ToInt32(cmbQuanLy.SelectedValue);

            //tenclb
            if (tenclb.Length > 50 || TestInput.StringIsNullEmptyWhiteSpace(tenclb))
            {
                MessageBox.Show("Tên CLB không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTenCLB.Focus();
                return;
            }


            o.TEN_CLB = tenclb;
            o.MA_QUAN_LY = maquanly;

            try
            {
                clbDAO.Update(o);
            }
            catch (Exception ex)
            {
                MessageUtliity.ShowException(ex);
            }

            MessageUtliity.ShowUpdateSuccess();
            Close();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
