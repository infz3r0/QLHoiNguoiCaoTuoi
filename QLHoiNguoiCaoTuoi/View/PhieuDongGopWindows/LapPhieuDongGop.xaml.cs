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

namespace QLHoiNguoiCaoTuoi.View.PhieuDongGopWindows
{
    /// <summary>
    /// Interaction logic for LapPhieuDongGop.xaml
    /// </summary>
    public partial class LapPhieuDongGop : Window
    {
        private PhieuDongGopDAO pdgDAO;
        public LapPhieuDongGop()
        {
            InitializeComponent();

            pdgDAO = new PhieuDongGopDAO();
        }

        private void TxbSoTien_GotFocus(object sender, RoutedEventArgs e)
        {
            txbSoTien.SelectAll();
        }

        private void LoadDefaultData()
        {
            List<DON_VI_DONG_GOP> dvs = new List<DON_VI_DONG_GOP>();
            using (Entities db = new Entities())
            {
                dvs = db.DON_VI_DONG_GOP.ToList();
            }

            cmbDonVi.ItemsSource = dvs;
            cmbDonVi.DisplayMemberPath = "TEN_DON_VI";
            cmbDonVi.SelectedValuePath = "MA_DON_VI";
            cmbDonVi.SelectedIndex = 0;

            dtpNgayLap.SelectedDate = DateTime.Now;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDefaultData();
            
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            decimal madonvi = Convert.ToDecimal(cmbDonVi.SelectedValue);
            DateTime ngaylap = (DateTime)dtpNgayLap.SelectedDate;
            string ssotien = txbSoTien.Text;
            decimal sotien = 0;
            bool isvalid = decimal.TryParse(ssotien, out sotien);

            if (ngaylap > DateTime.Now)
            {
                MessageBox.Show("Ngày lập không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                dtpNgayLap.Focus();
                return;
            }

            if (!isvalid)
            {
                MessageBox.Show("Số tiền không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbSoTien.Focus();
                return;
            }

            try
            {
                PHIEU_DONG_GOP n = new PHIEU_DONG_GOP();
                n.NGAY_DONG_GOP = ngaylap;
                n.SO_TIEN_DONG_GOP = sotien;
                n.MA_DON_VI = madonvi;

                pdgDAO.Create(n);
            }
            catch (Exception ex)
            {
                MessageUtliity.ShowException(ex);
                return;
            }

            MessageUtliity.ShowInsertSuccess();
            Close();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
