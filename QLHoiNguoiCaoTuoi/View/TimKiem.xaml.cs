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

namespace QLHoiNguoiCaoTuoi.View
{
    /// <summary>
    /// Interaction logic for TimKiem.xaml
    /// </summary>
    public partial class TimKiem : Window
    {
        private TimKiemDAO tkDAO;

        public TimKiem()
        {
            InitializeComponent();

            tkDAO = new TimKiemDAO();
        }

        private void LoadDefaultData()
        {
            //cmb thanh vien
            List<ComboBoxPairs> tvs = new List<ComboBoxPairs>();
            tvs.Add(new ComboBoxPairs("Họ tên", "1"));
            tvs.Add(new ComboBoxPairs("Địa chỉ", "2"));
            tvs.Add(new ComboBoxPairs("Ngày tham gia", "3"));
            cmbThanhVien.ItemsSource = tvs;
            cmbThanhVien.DisplayMemberPath = "_Key";
            cmbThanhVien.SelectedValuePath = "_Value";
            cmbThanhVien.SelectedIndex = 0;

            //cmb hoat dong
            List<ComboBoxPairs> hds = new List<ComboBoxPairs>();
            hds.Add(new ComboBoxPairs("Nội dung", "1"));
            hds.Add(new ComboBoxPairs("Tháng/Năm", "2"));
            cmbHoatDong.ItemsSource = hds;
            cmbHoatDong.DisplayMemberPath = "_Key";
            cmbHoatDong.SelectedValuePath = "_Value";
            cmbHoatDong.SelectedIndex = 0;

            //cmb don vi
            List<ComboBoxPairs> dvs = new List<ComboBoxPairs>();
            dvs.Add(new ComboBoxPairs("Tên", "1"));
            dvs.Add(new ComboBoxPairs("Địa chỉ", "2"));
            dvs.Add(new ComboBoxPairs("Email", "3"));
            cmbDonViDG.ItemsSource = dvs;
            cmbDonViDG.DisplayMemberPath = "_Key";
            cmbDonViDG.SelectedValuePath = "_Value";
            cmbDonViDG.SelectedIndex = 0;
        }

        private void LoadDataThanhVien()
        {
            lblTitle.Content = "Tìm kiếm thông tin thành viên";
            lblDescription.Content = "Tìm theo họ tên, địa chỉ, ngày tham gia";

            brdThanhVien.Visibility = Visibility.Visible;
            brdHoatDong.Visibility = Visibility.Hidden;
            brdDonViDG.Visibility = Visibility.Hidden;

        }

        private void LoadDataHoatDong()
        {
            lblTitle.Content = "Tìm kiếm thông tin hoạt động";
            lblDescription.Content = "Tìm theo nội dung, tháng/năm";

            brdThanhVien.Visibility = Visibility.Hidden;
            brdHoatDong.Visibility = Visibility.Visible;
            brdDonViDG.Visibility = Visibility.Hidden;
        }

        private void LoadDataDonVi()
        {
            lblTitle.Content = "Tìm kiếm thông tin đơn vị đóng góp";
            lblDescription.Content = "Tìm theo tên, địa chỉ, email";

            brdThanhVien.Visibility = Visibility.Hidden;
            brdHoatDong.Visibility = Visibility.Hidden;
            brdDonViDG.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDefaultData();
            LoadDataThanhVien();
        }

        private void BtnThanhVien_Click(object sender, RoutedEventArgs e)
        {
            LoadDataThanhVien();
        }

        private void BtnHoatDong_Click(object sender, RoutedEventArgs e)
        {
            LoadDataHoatDong();
        }

        private void BtnDonViDG_Click(object sender, RoutedEventArgs e)
        {
            LoadDataDonVi();
        }

        private void TimThanhVien_TheoHoTen(string hoten)
        {
            hoten = hoten.Trim();
            List<SP_PKG_TIMKIEMTHANHVIEN_TIMTHEOHOTEN_Result> r = tkDAO.TimKiemThanhVien_TheoHoTen(hoten);
            foreach (SP_PKG_TIMKIEMTHANHVIEN_TIMTHEOHOTEN_Result tv in r)
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
            dgThanhVien.ItemsSource = r;

            dgThanhVien.Columns[0].Header = "Mã thành viên";
            dgThanhVien.Columns[1].Header = "Họ";
            dgThanhVien.Columns[2].Header = "Tên";
            dgThanhVien.Columns[3].Header = "Ngày sinh";
            dgThanhVien.Columns[4].Header = "Tháng sinh";
            dgThanhVien.Columns[5].Header = "Năm sinh";
            dgThanhVien.Columns[6].Header = "Giới tính";
            dgThanhVien.Columns[7].Header = "Địa chỉ";
            dgThanhVien.Columns[8].Header = "Ngày tham gia";
            dgThanhVien.Columns[9].Header = "Tên khu phố";
        }

        private void SearchThanhVien()
        {
            string type = cmbThanhVien.SelectedValue.ToString();
            switch (type)
            {
                case "1":
                    //ho ten
                    TimThanhVien_TheoHoTen(txbThanhVien.Text);
                    break;
                case "2":
                    //dia chi

                    break;

                case "3":
                    //ngay tham gia

                    break;
            }
        }

        private void BtnSearchThanhVien_Click(object sender, RoutedEventArgs e)
        {
            SearchThanhVien();
        }

        private void BtnSearchHoatDong_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSearchDonViDG_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TxbThanhVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchThanhVien();
            }
        }
    }
}
