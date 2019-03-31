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

namespace QLHoiNguoiCaoTuoi.View.TVCLBWindows
{
    /// <summary>
    /// Interaction logic for Them.xaml
    /// </summary>
    public partial class Them : Window
    {
        private ThanhVienCLBDAO thanhVienCLBDAO;
        private CLB clb;
        private List<V_THANH_VIEN> tv_not_in_clb;
        private List<V_THANH_VIEN> tv_clb;

        public Them(CLB clb)
        {
            InitializeComponent();

            thanhVienCLBDAO = new ThanhVienCLBDAO();
            this.clb = clb;
        }

        private void LoadData()
        {
            List<decimal> ma_tv_clb = new List<decimal>();
            tv_not_in_clb = new List<V_THANH_VIEN>();            
            using (Entities db = new Entities())
            {
                ma_tv_clb = db.THANH_VIEN_CLB.Where(x=>x.MA_CLB == clb.MA_CLB).Select(x=>x.MA_THANH_VIEN).ToList();
                tv_not_in_clb = db.V_THANH_VIEN.Where(x => !ma_tv_clb.Contains(x.MA_THANH_VIEN)).ToList();
            }
            foreach (V_THANH_VIEN tv in tv_not_in_clb)
            {
                if (tv.GIOI_TINH.Equals("M"))
                {
                    tv.GIOI_TINH = "Nam";
                }
                else
                {
                    tv.GIOI_TINH = "Nữ";
                }
            }

            dgTVNotInCLB.ItemsSource = tv_not_in_clb;
            dgTVNotInCLB.Columns[0].Header = "Mã thành viên";
            dgTVNotInCLB.Columns[1].Header = "Họ";
            dgTVNotInCLB.Columns[2].Header = "Tên";
            dgTVNotInCLB.Columns[3].Header = "Ngày";
            dgTVNotInCLB.Columns[4].Header = "Tháng";
            dgTVNotInCLB.Columns[5].Header = "Năm sinh";
            dgTVNotInCLB.Columns[6].Header = "Giới tính";
            dgTVNotInCLB.Columns[7].Header = "Địa chỉ";
            dgTVNotInCLB.Columns[8].Header = "Ngày tham gia";
            dgTVNotInCLB.Columns[9].Header = "Mã khu phố";
            dgTVNotInCLB.Columns[10].Header = "Tên khu phố";

            dgTVNotInCLB.Columns[8].Visibility = Visibility.Hidden;
            dgTVNotInCLB.Columns[9].Visibility = Visibility.Hidden;

            tv_clb = new List<V_THANH_VIEN>();
            dgTVCLB.ItemsSource = tv_clb;
            dgTVCLB.Columns[0].Header = "Mã thành viên";
            dgTVCLB.Columns[1].Header = "Họ";
            dgTVCLB.Columns[2].Header = "Tên";
            dgTVCLB.Columns[3].Header = "Ngày";
            dgTVCLB.Columns[4].Header = "Tháng";
            dgTVCLB.Columns[5].Header = "Năm sinh";
            dgTVCLB.Columns[6].Header = "Giới tính";
            dgTVCLB.Columns[7].Header = "Địa chỉ";
            dgTVCLB.Columns[8].Header = "Ngày tham gia";
            dgTVCLB.Columns[9].Header = "Mã khu phố";
            dgTVCLB.Columns[10].Header = "Tên khu phố";

            dgTVCLB.Columns[8].Visibility = Visibility.Hidden;
            dgTVCLB.Columns[9].Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txbCLB.Text = clb.TEN_CLB;
            LoadData();
        }

        private void TxbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (tv_clb.Count > 0)
            {
                foreach (V_THANH_VIEN tv in tv_clb)
                {
                    THANH_VIEN_CLB n = new THANH_VIEN_CLB();
                    n.MA_CLB = clb.MA_CLB;
                    n.MA_THANH_VIEN = tv.MA_THANH_VIEN;
                    n.NGAY_THAM_GIA_CLB = DateTime.Now;
                    try
                    {
                        thanhVienCLBDAO.Insert(n);
                    }
                    catch (Exception ex)
                    {
                        MessageUtliity.ShowException(ex);
                        return;
                    }
                }
                MessageUtliity.ShowInsertSuccess();
                Close();
            }
            
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TxbFilter_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void DgTV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DgTV_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void DgTVNotInCLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            V_THANH_VIEN tv = (V_THANH_VIEN)dgTVNotInCLB.SelectedItem;
            if (tv != null)
            {
                tv_clb.Add(tv);
                tv_not_in_clb.Remove(tv);
                dgTVNotInCLB.Items.Refresh();
                dgTVCLB.Items.Refresh();
            }
        }

        private void DgTVCLB_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            V_THANH_VIEN tv = (V_THANH_VIEN)dgTVCLB.SelectedItem;
            if (tv != null)
            {
                tv_not_in_clb.Add(tv);
                tv_clb.Remove(tv);
                dgTVNotInCLB.Items.Refresh();
                dgTVCLB.Items.Refresh();
            }
        }
    }
}
