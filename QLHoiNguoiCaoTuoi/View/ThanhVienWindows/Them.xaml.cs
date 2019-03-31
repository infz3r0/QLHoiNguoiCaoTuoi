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
using QLHoiNguoiCaoTuoi.View;
using QLHoiNguoiCaoTuoi.Utility;

namespace QLHoiNguoiCaoTuoi.View.ThanhVienWindows
{
    /// <summary>
    /// Interaction logic for Them.xaml
    /// </summary>
    public partial class Them : Window
    {
        ThanhVienDAO thanhVienDAO;

        public Them()
        {
            InitializeComponent();

            thanhVienDAO = new ThanhVienDAO();
        }

        private void LoadDefaultData()
        {
            //ngay
            List<ComboBoxPairs> days = new List<ComboBoxPairs>();
            days.Add(new ComboBoxPairs("", null));
            for (int i = 1; i <= 31; i++)
            {
                days.Add(new ComboBoxPairs(i.ToString(), i.ToString()));
            }

            cmbNgay.DisplayMemberPath = "_Key";
            cmbNgay.SelectedValuePath = "_Value";

            cmbNgay.ItemsSource = days;
            cmbNgay.SelectedIndex = 0;

            //thang
            List<ComboBoxPairs> months = new List<ComboBoxPairs>();
            months.Add(new ComboBoxPairs("", null));
            for (int i = 1; i <= 12; i++)
            {
                months.Add(new ComboBoxPairs(i.ToString(), i.ToString()));
            }

            cmbThang.DisplayMemberPath = "_Key";
            cmbThang.SelectedValuePath = "_Value";

            cmbThang.ItemsSource = months;
            cmbThang.SelectedIndex = 0;

            //nam
            List<ComboBoxPairs> years = new List<ComboBoxPairs>();
            for (int i = 1900; i <= 2200; i++)
            {
                years.Add(new ComboBoxPairs(i.ToString(), i.ToString()));
            }

            cmbNam.DisplayMemberPath = "_Key";
            cmbNam.SelectedValuePath = "_Value";

            cmbNam.ItemsSource = years;
            cmbNam.SelectedIndex = 0;

            //gioi_tinh
            List<ComboBoxPairs> gioi_tinhL = new List<ComboBoxPairs>
            {
                new ComboBoxPairs("Nam", "M"),
                new ComboBoxPairs("Nữ", "F")
            };

            cmbGioiTinh.DisplayMemberPath = "_Key";
            cmbGioiTinh.SelectedValuePath = "_Value";

            cmbGioiTinh.ItemsSource = gioi_tinhL;
            cmbGioiTinh.SelectedIndex = 0;

            //khu_pho
            List<KHU_PHO> khu_phoL = new List<KHU_PHO>();
            using (Entities db = new Entities())
            {
                khu_phoL = db.KHU_PHO.ToList();
            }

            cmbKhuPho.DisplayMemberPath = "TEN_KHU_PHO";
            cmbKhuPho.SelectedValuePath = "MA_KHU_PHO";

            cmbKhuPho.ItemsSource = khu_phoL;
            cmbKhuPho.SelectedIndex = 0;

            //ngay_tham_gia
            dtpNgayThamGia.SelectedDate = DateTime.Now;
        }

        private void ClearInput()
        {
            txbHo.Clear();
            txbTen.Clear();
            cmbNgay.SelectedIndex = 0;
            cmbThang.SelectedIndex = 0;
            cmbNam.SelectedIndex = 0;
            cmbGioiTinh.SelectedIndex = 0;
            txbDiaChi.Clear();
            cmbKhuPho.SelectedIndex = 0;
            dtpNgayThamGia.SelectedDate = DateTime.Now;
        }

        private void TxbHo_GotFocus(object sender, RoutedEventArgs e)
        {
            txbHo.SelectAll();
        }

        private void TxbTen_GotFocus(object sender, RoutedEventArgs e)
        {
            txbTen.SelectAll();
        }

        private void CmbNgay_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CmbThang_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CmbNam_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void CmbGioiTinh_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TxbDiaChi_GotFocus(object sender, RoutedEventArgs e)
        {
            txbDiaChi.SelectAll();
        }

        private void CmbKhuPho_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void DtpNgayThamGia_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string ho = txbHo.Text;
            string ten = txbTen.Text;
            string ngay = cmbNgay.SelectedValue == null ? null : cmbNgay.SelectedValue.ToString();
            string thang = cmbThang.SelectedValue == null ? null : cmbThang.SelectedValue.ToString();
            string nam = cmbNam.SelectedValue.ToString();
            bool ngaysinhisvalid = true;
            if (ngay != null && thang != null)
            {
                string sngaysinh = ngay + "/" + ngay + "/" + nam;
                DateTime ngaysinh = new DateTime();                
                ngaysinhisvalid = DateTime.TryParse(sngaysinh, out ngaysinh);
            }
            
            string gioitinh = cmbGioiTinh.SelectedValue.ToString();
            string diachi = txbDiaChi.Text;
            DateTime ngaythamgia = (DateTime)dtpNgayThamGia.SelectedDate;
            int makhupho = Convert.ToInt32(cmbKhuPho.SelectedValue.ToString());

            if (ho.Length > 50 || TestInput.StringIsNullEmptyWhiteSpace(ho))
            {
                MessageBox.Show("Họ không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbHo.Focus();
                return;
            }
            if (ten.Length > 20 || TestInput.StringIsNullEmptyWhiteSpace(ten))
            {
                MessageBox.Show("Tên không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTen.Focus();
                return;
            }
            if (!ngaysinhisvalid)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbNgay.Focus();
                return;
            }
            if (diachi.Length > 200 || TestInput.StringIsNullEmptyWhiteSpace(diachi))
            {
                MessageBox.Show("Địa chỉ không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbDiaChi.Focus();
                return;
            }

            THANH_VIEN n = new THANH_VIEN();
            n.HO = ho;
            n.TEN = ten;
            if (ngay != null && thang != null)
            {
                n.NGAY_SINH = Convert.ToByte(ngay);
                n.THANG_SINH = Convert.ToByte(thang);
            }            
            n.NAM_SINH = Convert.ToInt16(nam);
            n.GIOI_TINH = gioitinh;
            n.DIA_CHI = diachi;
            n.NGAY_THAM_GIA = ngaythamgia;
            n.MA_KHU_PHO = makhupho;

            try
            {
                thanhVienDAO.Insert(n);
            }
            catch (Exception ex)
            {
                MessageUtliity.ShowException(ex);
                return;
            }

            MessageUtliity.ShowInsertSuccess();
            ClearInput();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTitle.Content = "Thêm thành viên";
            LoadDefaultData();
            txbHo.Focus();
        }
    }
}
