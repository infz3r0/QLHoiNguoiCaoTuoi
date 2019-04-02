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

namespace QLHoiNguoiCaoTuoi.View.ThuWindows
{
    /// <summary>
    /// Interaction logic for LapPhieuThu.xaml
    /// </summary>
    public partial class LapPhieuThu : Window
    {
        private PhieuThuDAO phieuThuDAO;

        public LapPhieuThu()
        {
            InitializeComponent();

            phieuThuDAO = new PhieuThuDAO();
        }

        private void LoadDefaultData()
        {
            //Ng lap
            System.Collections.IEnumerable bchs = null;
            using (Entities db = new Entities())
            {
                bchs = db.V_TV_BAN_CHAP_HANH.Select(x => new { HOTEN = x.HO + " " + x.TEN, x.MA_BCH }).ToList();
            }

            cmbNguoiLap.ItemsSource = bchs;
            cmbNguoiLap.DisplayMemberPath = "HOTEN";
            cmbNguoiLap.SelectedValuePath = "MA_BCH";
            cmbNguoiLap.SelectedIndex = 0;

            //TV
            //System.Collections.IEnumerable tvs = null;

            using (Entities db = new Entities())
            {
                List<decimal> ma_bchs = db.TV_BAN_CHAP_HANH.Select(x => x.MA_BCH).ToList();
                var tvs = db.THANH_VIEN.Where(x=>!ma_bchs.Contains(x.MA_THANH_VIEN)).Select(x => new { HOTEN = x.HO + " " + x.TEN, x.MA_THANH_VIEN }).ToList();
                tvs.Add(new { HOTEN = "", MA_THANH_VIEN = (decimal)-1 });
                cmbNguoiNop.ItemsSource = tvs;
            }
            
            cmbNguoiNop.DisplayMemberPath = "HOTEN";
            cmbNguoiNop.SelectedValuePath = "MA_THANH_VIEN";
            cmbNguoiNop.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDefaultData();
            dtpNgayLapPhieu.SelectedDate = DateTime.Now;
            ClearInput();
        }

        private void ClearInput()
        {
            txbNoiDung.Clear();
            txbSoTien.Clear();

        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            DateTime ngaylap = (DateTime)dtpNgayLapPhieu.SelectedDate;
            string noidung = txbNoiDung.Text;
            string ssotien = txbSoTien.Text;
            decimal sotien = 0;
            bool isvalid = decimal.TryParse(ssotien, out sotien);
            decimal manglap = Convert.ToDecimal(cmbNguoiLap.SelectedValue);
            decimal mangnop = Convert.ToDecimal(cmbNguoiNop.SelectedValue);

            //ngay lap
            if (ngaylap > DateTime.Now)
            {
                MessageBox.Show("Ngày lập phiếu không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                dtpNgayLapPhieu.Focus();
                return;
            }

            //noi dung
            if (noidung.Length > 128 || TestInput.StringIsNullEmptyWhiteSpace(noidung))
            {
                MessageBox.Show("Nội dung không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbNoiDung.Focus();
                return;
            }

            //so tien
            if (!isvalid)
            {
                MessageBox.Show("Số tiền không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbSoTien.Focus();
                return;
            }

            try
            {
                PHIEU_THU n = new PHIEU_THU();
                n.NGAY_LAP_PHIEU_THU = ngaylap;
                n.NOI_DUNG_PHIEU_THU = noidung;
                n.SO_TIEN_THU = sotien;
                n.MA_BCH = manglap;
                if (mangnop != -1)
                {
                    n.MA_THANH_VIEN = mangnop;
                }

                phieuThuDAO.Create(n);
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

        private void TxbNoiDung_GotFocus(object sender, RoutedEventArgs e)
        {
            txbNoiDung.SelectAll();
        }

        private void TxbSoTien_GotFocus(object sender, RoutedEventArgs e)
        {
            txbSoTien.SelectAll();
        }

    }
}
