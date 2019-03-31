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

namespace QLHoiNguoiCaoTuoi.View.BCHWindows
{
    /// <summary>
    /// Interaction logic for Sua.xaml
    /// </summary>
    public partial class Sua : Window
    {
        private TVBanChapHanhDAO bchDAO;
        private TV_BAN_CHAP_HANH bch;

        public Sua(TV_BAN_CHAP_HANH bch)
        {
            InitializeComponent();
            bchDAO = new TVBanChapHanhDAO();
            this.bch = bch;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //chucvu
            List<CHUC_VU> cvs = new List<CHUC_VU>();
            using (Entities db = new Entities())
            {
                cvs = db.CHUC_VU.ToList();
            }

            cmbChucVu.ItemsSource = cvs;
            cmbChucVu.DisplayMemberPath = "TEN_CHUC_VU";
            cmbChucVu.SelectedValuePath = "MA_CHUC_VU";
            cmbChucVu.SelectedValue = bch.MA_CHUC_VU;

            txbDanToc.Text = bch.DAN_TOC;
            txbTonGiao.Text = bch.TON_GIAO;
            txbNgheNghiep.Text = bch.NGHE_NGHIEP;
            txbDonViCongTac.Text = bch.DON_VI_CONG_TAC;
            txbTrinhDoHocVan.Text = bch.TRINH_DO_HOC_VAN;
            txbTrinhDoChuyenMon.Text = bch.TRINH_DO_CHUYEN_MON;
            txbTrinhDoLyLuanChinhTri.Text = bch.TRINH_DO_LY_LUAN_CHINH_TRI;
        }

        private void ClearInput()
        {
            txbDanToc.Clear();
            txbTonGiao.Clear();
            txbNgheNghiep.Clear();
            txbDonViCongTac.Clear();
            txbTrinhDoHocVan.Clear();
            txbTrinhDoChuyenMon.Clear();
            txbTrinhDoLyLuanChinhTri.Clear();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string dantoc = txbDanToc.Text;
            string tongiao = txbTonGiao.Text;
            string nghenghiep = txbNgheNghiep.Text;
            string donvicongtac = txbDonViCongTac.Text;
            string tdhocvan = txbTrinhDoHocVan.Text;
            string tdchuyenmon = txbTrinhDoChuyenMon.Text;
            string tdchinhtri = txbTrinhDoLyLuanChinhTri.Text;


            if (dantoc.Length > 20 || TestInput.StringIsNullEmptyWhiteSpace(dantoc))
            {
                MessageBox.Show("Dân tộc không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbDanToc.Focus();
                return;
            }

            if (tongiao.Length > 20 || TestInput.StringIsNullEmptyWhiteSpace(tongiao))
            {
                MessageBox.Show("Tôn giáo không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTonGiao.Focus();
                return;
            }

            if (nghenghiep.Length > 30 || TestInput.StringIsNullEmptyWhiteSpace(nghenghiep))
            {
                MessageBox.Show("Nghề nghiệp không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbNgheNghiep.Focus();
                return;
            }

            if (donvicongtac.Length > 100 || TestInput.StringIsNullEmptyWhiteSpace(donvicongtac))
            {
                MessageBox.Show("Đơn vị công tác không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbDonViCongTac.Focus();
                return;
            }

            if (tdhocvan.Length > 20 || TestInput.StringIsNullEmptyWhiteSpace(tdhocvan))
            {
                MessageBox.Show("TĐ học vấn không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTrinhDoHocVan.Focus();
                return;
            }

            if (tdchuyenmon.Length > 30 || TestInput.StringIsNullEmptyWhiteSpace(tdchuyenmon))
            {
                MessageBox.Show("TĐ chuyên môn không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTrinhDoChuyenMon.Focus();
                return;
            }

            if (tdchinhtri.Length > 30 || TestInput.StringIsNullEmptyWhiteSpace(tdchinhtri))
            {
                MessageBox.Show("TĐ LL chính trị không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTrinhDoLyLuanChinhTri.Focus();
                return;
            }

            
            bch.DAN_TOC = dantoc;
            bch.TON_GIAO = tongiao;
            bch.NGHE_NGHIEP = nghenghiep;
            bch.DON_VI_CONG_TAC = donvicongtac;
            bch.TRINH_DO_HOC_VAN = tdhocvan;
            bch.TRINH_DO_CHUYEN_MON = tdchuyenmon;
            bch.TRINH_DO_LY_LUAN_CHINH_TRI = tdchinhtri;
            bch.MA_CHUC_VU = Convert.ToDecimal(cmbChucVu.SelectedValue);
            try
            {
                bchDAO.Update(bch);
            }
            catch (Exception ex)
            {
                MessageUtliity.ShowException(ex);
                return;
            }
            MessageUtliity.ShowUpdateSuccess();
            Close();
        }

        private void TxbDanToc_GotFocus(object sender, RoutedEventArgs e)
        {
            txbDanToc.SelectAll();
        }

        private void TxbTonGiao_GotFocus(object sender, RoutedEventArgs e)
        {
            txbTonGiao.SelectAll();
        }

        private void TxbNgheNghiep_GotFocus(object sender, RoutedEventArgs e)
        {
            txbNgheNghiep.SelectAll();
        }

        private void TxbDonViCongTac_GotFocus(object sender, RoutedEventArgs e)
        {
            txbDonViCongTac.SelectAll();
        }

        private void TxbTrinhDoHocVan_GotFocus(object sender, RoutedEventArgs e)
        {
            txbTrinhDoHocVan.SelectAll();
        }

        private void TxbTrinhDoChuyenMon_GotFocus(object sender, RoutedEventArgs e)
        {
            txbTrinhDoChuyenMon.SelectAll();
        }

        private void TxbTrinhDoLyLuanChinhTri_GotFocus(object sender, RoutedEventArgs e)
        {
            txbTrinhDoLyLuanChinhTri.SelectAll();
        }

    }
}
