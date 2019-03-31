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
    /// Interaction logic for Them.xaml
    /// </summary>
    public partial class Them : Window
    {
        private TVBanChapHanhDAO bchDAO;
        private SolidColorBrush brushRed, brushGreen;

        public Them()
        {
            InitializeComponent();
            bchDAO = new TVBanChapHanhDAO();

            brushRed = new SolidColorBrush(Color.FromRgb(255, 209, 209));
            brushGreen = new SolidColorBrush(Color.FromRgb(176, 251, 169));
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadTV()
        {
            List<decimal> ma_bchs = new List<decimal>();
            System.Collections.IEnumerable tv_not_bch = null;
            using (Entities db = new Entities())
            {
                ma_bchs = db.TV_BAN_CHAP_HANH.Select(x => x.MA_BCH).ToList();
                tv_not_bch = db.THANH_VIEN.Where(x => !ma_bchs.Contains(x.MA_THANH_VIEN)).Select(x => new { HOTEN = x.HO + " " + x.TEN, x.MA_THANH_VIEN }).ToList();
            }

            //hoten
            cmbHoTen.ItemsSource = tv_not_bch;
            cmbHoTen.DisplayMemberPath = "HOTEN";
            cmbHoTen.SelectedValuePath = "MA_THANH_VIEN";
            cmbHoTen.SelectedIndex = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTV();

            //chucvu
            List<CHUC_VU> cvs = new List<CHUC_VU>();
            using (Entities db = new Entities())
            {
                cvs = db.CHUC_VU.ToList();
            }

            cmbChucVu.ItemsSource = cvs;
            cmbChucVu.DisplayMemberPath = "TEN_CHUC_VU";
            cmbChucVu.SelectedValuePath = "MA_CHUC_VU";
            cmbChucVu.SelectedIndex = 0;
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
            decimal ma_bch = Convert.ToDecimal(cmbHoTen.SelectedValue);
            string dantoc = txbDanToc.Text;
            string tongiao = txbTonGiao.Text;
            string nghenghiep = txbNgheNghiep.Text;
            string donvicongtac = txbDonViCongTac.Text;
            string tdhocvan = txbTrinhDoHocVan.Text;
            string tdchuyenmon = txbTrinhDoChuyenMon.Text;
            string tdchinhtri = txbTrinhDoLyLuanChinhTri.Text;

            string username = txbUsername.Text;
            string password = pwdNewPassword.Password;
            string repassword = pwdRePassword.Password;
            string email = txbEmail.Text;

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

            //test new password
            if (TestInput.StringIsNullEmptyWhiteSpace(password))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                pwdNewPassword.Focus();
                return;
            }

            if (TestInput.StringIsNullEmptyWhiteSpace(repassword))
            {
                MessageBox.Show("Password không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                pwdRePassword.Focus();
                return;
            }

            if (!password.Equals(repassword))
            {
                MessageBox.Show("Password không trùng khớp", "Password not match", MessageBoxButton.OK, MessageBoxImage.Warning);
                pwdNewPassword.Focus();
                return;
            }

            TV_BAN_CHAP_HANH n = new TV_BAN_CHAP_HANH();
            n.MA_BCH = ma_bch;
            n.DAN_TOC = dantoc;
            n.TON_GIAO = tongiao;
            n.NGHE_NGHIEP = nghenghiep;
            n.DON_VI_CONG_TAC = donvicongtac;
            n.TRINH_DO_HOC_VAN = tdhocvan;
            n.TRINH_DO_CHUYEN_MON = tdchuyenmon;
            n.TRINH_DO_LY_LUAN_CHINH_TRI = tdchinhtri;
            n.LUONG = 1;
            n.MA_CHUC_VU = Convert.ToDecimal(cmbChucVu.SelectedValue);
            n.USERNAME = username;
            n.PASSWORD = password;
            n.EMAIL = email;
            try
            {
                bchDAO.Insert(n);
            }
            catch (Exception ex)
            {
                MessageUtliity.ShowException(ex);
                return;
            }
            MessageUtliity.ShowInsertSuccess();
            Close();
        }

        private void TestPasswordEffect()
        {
            string newpassword = pwdNewPassword.Password;
            string repassword = pwdRePassword.Password;

            if (!TestInput.StringIsNullEmptyWhiteSpace(newpassword) || !TestInput.StringIsNullEmptyWhiteSpace(repassword))
            {
                if (!newpassword.Equals(repassword))
                {
                    pwdNewPassword.Background = brushRed;
                    pwdRePassword.Background = brushRed;
                }
                else
                {
                    pwdNewPassword.Background = brushGreen;
                    pwdRePassword.Background = brushGreen;
                }
            }
            else
            {
                pwdNewPassword.Background = Brushes.White;
                pwdRePassword.Background = Brushes.White;
            }
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

        private void TxbEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            txbEmail.SelectAll();
        }

        private void TxbUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txbUsername.SelectAll();
        }

        private void PwdNewPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            pwdNewPassword.SelectAll();
        }

        private void PwdRePassword_GotFocus(object sender, RoutedEventArgs e)
        {
            pwdRePassword.SelectAll();
        }

        private void PwdNewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TestPasswordEffect();
        }

        private void PwdRePassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            TestPasswordEffect();
        }
    }
}
