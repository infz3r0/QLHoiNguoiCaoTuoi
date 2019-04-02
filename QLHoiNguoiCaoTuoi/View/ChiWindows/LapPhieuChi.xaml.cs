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

namespace QLHoiNguoiCaoTuoi.View.ChiWindows
{
    /// <summary>
    /// Interaction logic for LapPhieuChi.xaml
    /// </summary>
    public partial class LapPhieuChi : Window
    {
        PhieuChiDAO phieuChiDAO;

        public LapPhieuChi()
        {
            InitializeComponent();

            phieuChiDAO = new PhieuChiDAO();
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
                List<HOAT_DONG> hds = db.HOAT_DONG.ToList();
                HOAT_DONG hdnull = new HOAT_DONG();
                hdnull.MA_HOAT_DONG = -1;
                hdnull.NOI_DUNG_HOAT_DONG = "";
                hds.Add(hdnull);
                cmbHoatDong.ItemsSource = hds;
            }

            cmbHoatDong.DisplayMemberPath = "NOI_DUNG_HOAT_DONG";
            cmbHoatDong.SelectedValuePath = "MA_HOAT_DONG";
            cmbHoatDong.SelectedValue = -1;
        }

        private void ClearInput()
        {
            txbNoiDung.Clear();
            txbSoTien.Clear();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDefaultData();
            dtpNgayLapPhieu.SelectedDate = DateTime.Now;
            ClearInput();
        }

        private void TxbNoiDung_GotFocus(object sender, RoutedEventArgs e)
        {
            txbNoiDung.SelectAll();
        }

        private void TxbSoTien_GotFocus(object sender, RoutedEventArgs e)
        {
            txbSoTien.SelectAll();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            DateTime ngaylap = (DateTime)dtpNgayLapPhieu.SelectedDate;
            string noidung = txbNoiDung.Text;
            string ssotien = txbSoTien.Text;
            decimal sotien = 0;
            bool isvalid = decimal.TryParse(ssotien, out sotien);
            decimal manglap = Convert.ToDecimal(cmbNguoiLap.SelectedValue);
            decimal mahd = Convert.ToDecimal(cmbHoatDong.SelectedValue);

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
                PHIEU_CHI n = new PHIEU_CHI();
                n.NGAY_LAP_PHIEU_CHI = ngaylap;
                n.NOI_DUNG_CHI = noidung;
                n.SO_TIEN_CHI = sotien;
                n.MA_BCH = manglap;
                if (mahd != -1)
                {
                    n.MA_HOAT_DONG = mahd;
                }

                phieuChiDAO.Create(n);
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
