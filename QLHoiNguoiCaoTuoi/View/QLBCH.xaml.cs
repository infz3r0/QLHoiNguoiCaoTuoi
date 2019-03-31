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
using QLHoiNguoiCaoTuoi.View.BCHWindows;
using QLHoiNguoiCaoTuoi.View.ChucVuWindows;

namespace QLHoiNguoiCaoTuoi.View
{
    /// <summary>
    /// Interaction logic for QLBCH.xaml
    /// </summary>
    public partial class QLBCH : Window
    {
        TVBanChapHanhDAO bchDAO;

        public QLBCH()
        {
            InitializeComponent();

            bchDAO = new TVBanChapHanhDAO();
        }

        private void LoadDataBCH()
        {
            lblTitle.Content = "Quản lý ban chấp hành";
            lblDescription.Content = "Thêm, sửa, xóa, ban chấp hành";

            List<V_TV_BAN_CHAP_HANH> bchs = new List<V_TV_BAN_CHAP_HANH>();
            using (Entities db = new Entities())
            {
                bchs = db.V_TV_BAN_CHAP_HANH.ToList();
            }

            dgBCH.ItemsSource = bchs;
            dgBCH.Columns[0].Header = "Mã BCH";
            dgBCH.Columns[1].Header = "Họ";
            dgBCH.Columns[2].Header = "Tên";
            dgBCH.Columns[3].Header = "Dân tộc";
            dgBCH.Columns[4].Header = "Tôn giáo";
            dgBCH.Columns[5].Header = "Nghề nghiệp";
            dgBCH.Columns[6].Header = "Đơn vị công tác";
            dgBCH.Columns[7].Header = "TĐ Học vấn";
            dgBCH.Columns[8].Header = "TĐ chuyên môn";
            dgBCH.Columns[9].Header = "TĐ LL Chính trị";
            dgBCH.Columns[10].Header = "Lương";
            dgBCH.Columns[11].Header = "Mã chức vụ";
            dgBCH.Columns[12].Header = "Tên chức vụ";

            dgBCH.Columns[11].Visibility = Visibility.Hidden;
        }

        private void LoadDataCV()
        {
            lblTitle.Content = "Quản lý chức vụ";
            lblDescription.Content = "Sửa hệ số lương";

            List<V_CHUC_VU> cvs = new List<V_CHUC_VU>();
            using (Entities db = new Entities())
            {
                cvs = db.V_CHUC_VU.ToList();
            }

            dgCV.ItemsSource = cvs;
            dgCV.Columns[0].Header = "Mã chức vụ";
            dgCV.Columns[1].Header = "Tên chức vụ";
            dgCV.Columns[2].Header = "Hệ số lương";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            brdBCH.Visibility = Visibility.Visible;
            brdChucVu.Visibility = Visibility.Hidden;
            LoadDataBCH();
        }

        private void BtnBCH_Click(object sender, RoutedEventArgs e)
        {
            brdBCH.Visibility = Visibility.Visible;
            brdChucVu.Visibility = Visibility.Hidden;
            LoadDataBCH();
        }

        private void BtnChucVu_Click(object sender, RoutedEventArgs e)
        {
            brdBCH.Visibility = Visibility.Hidden;
            brdChucVu.Visibility = Visibility.Visible;
            LoadDataCV();
        }

        private void BtnThemBCH_Click(object sender, RoutedEventArgs e)
        {
            BCHWindows.Them w = new BCHWindows.Them();
            w.Owner = this;
            w.ShowDialog();
            LoadDataBCH();
        }

        private void BtnSuaBCH_Click(object sender, RoutedEventArgs e)
        {
            V_TV_BAN_CHAP_HANH item = (V_TV_BAN_CHAP_HANH)dgBCH.SelectedItem;
            
            if (item != null)
            {
                TV_BAN_CHAP_HANH bch = new TV_BAN_CHAP_HANH();
                bch.MA_BCH = item.MA_BCH;
                bch.DAN_TOC = item.DAN_TOC;
                bch.TON_GIAO = item.TON_GIAO;
                bch.NGHE_NGHIEP = item.NGHE_NGHIEP;
                bch.DON_VI_CONG_TAC = item.DON_VI_CONG_TAC;
                bch.TRINH_DO_HOC_VAN = item.TRINH_DO_HOC_VAN;
                bch.TRINH_DO_CHUYEN_MON = item.TRINH_DO_CHUYEN_MON;
                bch.TRINH_DO_LY_LUAN_CHINH_TRI = item.TRINH_DO_LY_LUAN_CHINH_TRI;
                bch.MA_CHUC_VU = item.MA_CHUC_VU;

                BCHWindows.Sua w = new BCHWindows.Sua(bch);
                w.Owner = this;
                w.ShowDialog();
                LoadDataBCH();

            }
        }

        private void BtnXoaBCH_Click(object sender, RoutedEventArgs e)
        {
            V_TV_BAN_CHAP_HANH item = (V_TV_BAN_CHAP_HANH)dgBCH.SelectedItem;
            if (item != null)
            {
                string msg = string.Format("Có chắc chắn xóa");
                MessageBoxResult result = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    TV_BAN_CHAP_HANH o = new TV_BAN_CHAP_HANH();
                    o.MA_BCH = item.MA_BCH;
                    try
                    {
                        bchDAO.Delete(o);
                    }
                    catch (Exception ex)
                    {
                        MessageUtliity.ShowException(ex);
                        return;
                    }

                    MessageUtliity.ShowDeleteSuccess();
                    LoadDataBCH();
                }

            }
        }

        private void BtnSuaCV_Click(object sender, RoutedEventArgs e)
        {
            V_CHUC_VU item = (V_CHUC_VU)dgCV.SelectedItem;

            if (item != null)
            {
                CHUC_VU cv = new CHUC_VU();
                cv.MA_CHUC_VU = item.MA_CHUC_VU;
                cv.TEN_CHUC_VU = item.TEN_CHUC_VU;
                cv.HE_SO_LUONG = item.HE_SO_LUONG;

                ChucVuWindows.Sua w = new ChucVuWindows.Sua(cv);
                w.Owner = this;
                w.ShowDialog();
                LoadDataCV();

            }
        }
    }
}
