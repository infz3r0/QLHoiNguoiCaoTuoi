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
using QLHoiNguoiCaoTuoi.View.ThanhVienWindows;

namespace QLHoiNguoiCaoTuoi.View
{
    /// <summary>
    /// Interaction logic for QLThanhVien.xaml
    /// </summary>
    public partial class QLThanhVien : Window
    {
        private ThanhVienDAO thanhVienDAO;

        private void LoadData()
        {
            List<V_THANH_VIEN> list = new List<V_THANH_VIEN>();
            using (Entities db = new Entities())
            {
                list = db.V_THANH_VIEN.OrderBy(x=>x.TEN).ToList();
            }
            foreach (V_THANH_VIEN tv in list)
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

            dgList.ItemsSource = list;
            dgList.Columns[0].Header = "Mã thành viên";
            dgList.Columns[1].Header = "Họ";
            dgList.Columns[2].Header = "Tên";
            dgList.Columns[3].Header = "Ngày sinh";
            dgList.Columns[4].Header = "Tháng sinh";
            dgList.Columns[5].Header = "Năm sinh";
            dgList.Columns[6].Header = "Giới tính";
            dgList.Columns[7].Header = "Địa chỉ";
            dgList.Columns[8].Header = "Ngày tham gia";
            dgList.Columns[9].Visibility = Visibility.Hidden;
            dgList.Columns[10].Header = "Tên khu phố";

        }

        public QLThanhVien()
        {
            InitializeComponent();

            thanhVienDAO = new ThanhVienDAO();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTitle.Content = "Quản lý thông tin thành viên";
            lblDescription.Content = "Thêm, sửa xóa thông tin thành viên";

            LoadData();
        }

        private void BtnThem_Click(object sender, RoutedEventArgs e)
        {
            Them w = new Them();
            w.Owner = this;
            w.ShowDialog();
            LoadData();
        }

        private void BtnSua_Click(object sender, RoutedEventArgs e)
        {
            V_THANH_VIEN item = (V_THANH_VIEN)dgList.SelectedItem;
            if (item != null)
            {
                THANH_VIEN o = new THANH_VIEN();
                o.MA_THANH_VIEN = item.MA_THANH_VIEN;
                o.HO = item.HO;
                o.TEN = item.TEN;
                o.NGAY_SINH = item.NGAY_SINH;
                o.THANG_SINH = item.THANG_SINH;
                o.NAM_SINH = item.NAM_SINH;
                o.GIOI_TINH = item.GIOI_TINH == "Nữ" ? "F" : "M";
                o.DIA_CHI = item.DIA_CHI;
                o.MA_KHU_PHO = item.MA_KHU_PHO;

                Sua w = new Sua(o);
                w.Owner = this;
                w.ShowDialog();
                LoadData();
            }
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            V_THANH_VIEN item = (V_THANH_VIEN)dgList.SelectedItem;
            if (item != null)
            {
                string msg = string.Format("Có chắc chắn xóa '{0} {1}'", item.HO, item.TEN);
                MessageBoxResult result = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    THANH_VIEN o = new THANH_VIEN();
                    o.MA_THANH_VIEN = item.MA_THANH_VIEN;
                    try
                    {
                        thanhVienDAO.Delete(o);
                    }
                    catch (Exception ex)
                    {
                        MessageUtliity.ShowException(ex);
                    }

                    MessageUtliity.ShowDeleteSuccess();
                    LoadData();
                }

            }
        }

        private void BtnThanhVien_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void DgList_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            }
        }
    }
}
