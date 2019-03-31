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
using QLHoiNguoiCaoTuoi.View.CLBWindows;
using QLHoiNguoiCaoTuoi.View.TVCLBWindows;

namespace QLHoiNguoiCaoTuoi.View
{
    /// <summary>
    /// Interaction logic for QLCLB.xaml
    /// </summary>
    public partial class QLCLB : Window
    {
        private CLBDAO clbDAO;
        private ThanhVienCLBDAO thanhVienCLBDAO;

        private void LoadDataCLB()
        {
            List<V_CLB> list = new List<V_CLB>();
            using (Entities db = new Entities())
            {
                list = db.V_CLB.ToList();
            }

            dgCLB.ItemsSource = list;
            dgCLB.Columns[0].Header = "Mã CLB";
            dgCLB.Columns[1].Header = "Tên CLB";
            dgCLB.Columns[2].Header = "Ngày thành lập";
            dgCLB.Columns[3].Visibility = Visibility.Hidden;
            dgCLB.Columns[4].Header = "Người quản lý";

            lblTitle.Content = "Quản lý câu lạc bộ";
            lblDescription.Content = "Thêm, sửa, xóa câu lạc bộ";
        }

        private void LoadDataTVCLB_CLB()
        {
            lblTitle.Content = "Quản lý thành viên câu lạc bộ";
            lblDescription.Content = "Thêm, xóa thành viên câu lạc bộ";

            List<CLB> clbs = new List<CLB>();
            using (Entities db = new Entities())
            {
                clbs = db.CLBs.ToList();
            }

            cmbCLB.DisplayMemberPath = "TEN_CLB";
            cmbCLB.SelectedValuePath = "MA_CLB";
            cmbCLB.ItemsSource = clbs;
            cmbCLB.SelectedIndex = 0;
        }

        private void LoadDataTVCLB_TV(decimal ma_clb)
        {
            List<V_THANH_VIEN_CLB> list = new List<V_THANH_VIEN_CLB>();
            using (Entities db = new Entities())
            {
                list = db.V_THANH_VIEN_CLB.Where(x => x.MA_CLB == ma_clb).ToList();
            }

            dgTVCLB.ItemsSource = list;
            dgTVCLB.Columns[0].Header = "Mã CLB";
            dgTVCLB.Columns[1].Header = "Mã thành viên";
            dgTVCLB.Columns[2].Header = "Họ";
            dgTVCLB.Columns[3].Header = "Tên";
            dgTVCLB.Columns[4].Header = "Ngày sinh";
            dgTVCLB.Columns[5].Header = "Tháng sinh";
            dgTVCLB.Columns[6].Header = "Năm sinh";
            dgTVCLB.Columns[7].Header = "Địa chỉ";
            dgTVCLB.Columns[8].Header = "Khu phố";
        }

        public QLCLB()
        {
            InitializeComponent();

            clbDAO = new CLBDAO();
            thanhVienCLBDAO = new ThanhVienCLBDAO();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            brdCLB.Visibility = Visibility.Visible;
            brdTVCLB.Visibility = Visibility.Hidden;
            LoadDataCLB();
        }

        private void BtnCLB_Click(object sender, RoutedEventArgs e)
        {
            brdCLB.Visibility = Visibility.Visible;
            brdTVCLB.Visibility = Visibility.Hidden;
            LoadDataCLB();
        }

        private void BtnTVCLB_Click(object sender, RoutedEventArgs e)
        {
            brdCLB.Visibility = Visibility.Hidden;
            brdTVCLB.Visibility = Visibility.Visible;
            LoadDataTVCLB_CLB();
        }

        private void BtnThemCLB_Click(object sender, RoutedEventArgs e)
        {
            CLBWindows.Them w = new CLBWindows.Them();
            w.Owner = this;
            w.ShowDialog();
            LoadDataCLB();
        }

        private void BtnSuaCLB_Click(object sender, RoutedEventArgs e)
        {
            V_CLB item = (V_CLB)dgCLB.SelectedItem;
            if (item != null)
            {
                CLB o = new CLB();
                o.MA_CLB = item.MA_CLB;
                o.NGAY_THANH_LAP_CLB = item.NGAY_THANH_LAP_CLB;
                o.MA_QUAN_LY = item.MA_QUAN_LY;

                CLBWindows.Sua w = new CLBWindows.Sua(o);
                w.Owner = this;
                w.ShowDialog();
                LoadDataCLB();
            }
        }

        private void BtnXoaCLB_Click(object sender, RoutedEventArgs e)
        {
            V_CLB item = (V_CLB)dgCLB.SelectedItem;
            if (item != null)
            {
                string msg = string.Format("Có chắc chắn xóa '{0}'", item.TEN_CLB);
                MessageBoxResult result = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    CLB o = new CLB();
                    o.MA_CLB = item.MA_CLB;
                    try
                    {
                        clbDAO.Delete(o);
                    }
                    catch (Exception ex)
                    {
                        MessageUtliity.ShowException(ex);
                        return;
                    }

                    MessageUtliity.ShowDeleteSuccess();
                    LoadDataCLB();
                }

            }
        }

        private void BtnThemTV_Click(object sender, RoutedEventArgs e)
        {
            CLB clb = new CLB();
            clb.MA_CLB = Convert.ToInt32(cmbCLB.SelectedValue);
            using (Entities db = new Entities())
            {
                clb = db.CLBs.Find(clb.MA_CLB);
            }
            TVCLBWindows.Them w = new TVCLBWindows.Them(clb);
            w.Owner = this;
            w.ShowDialog();
            LoadDataTVCLB_TV(clb.MA_CLB);
        }

        private void BtnXoaTV_Click(object sender, RoutedEventArgs e)
        {
            V_THANH_VIEN_CLB item = (V_THANH_VIEN_CLB)dgTVCLB.SelectedItem;
            if (item != null)
            {
                string msg = string.Format("Có chắc chắn xóa");
                MessageBoxResult result = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    THANH_VIEN_CLB o = new THANH_VIEN_CLB();
                    o.MA_CLB = item.MA_CLB;
                    o.MA_THANH_VIEN = item.MA_THANH_VIEN;
                    try
                    {
                        thanhVienCLBDAO.Delete(o);
                    }
                    catch (Exception ex)
                    {
                        MessageUtliity.ShowException(ex);
                        return;
                    }

                    MessageUtliity.ShowDeleteSuccess();
                    LoadDataTVCLB_TV(item.MA_CLB);
                }

            }
        }

        private void DgCLB_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            }
        }

        private void CmbCLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            decimal maclb = Convert.ToDecimal(cmbCLB.SelectedValue);
            LoadDataTVCLB_TV(maclb);
        }
    }
}
