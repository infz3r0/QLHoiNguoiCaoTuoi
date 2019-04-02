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
using QLHoiNguoiCaoTuoi.View.DonViDongGopWindows;
using QLHoiNguoiCaoTuoi.View.PhieuDongGopWindows;

namespace QLHoiNguoiCaoTuoi.View
{
    /// <summary>
    /// Interaction logic for QLDonViDongGop.xaml
    /// </summary>
    public partial class QLDongGop : Window
    {
        private DonViDongGopDAO dvDAO;
        private PhieuDongGopDAO pdgDAO;

        public QLDongGop()
        {
            InitializeComponent();

            dvDAO = new DonViDongGopDAO();
            pdgDAO = new PhieuDongGopDAO();
        }

        private void LoadDataDV()
        {
            lblTitle.Content = "Quản lý đơn vị đóng góp";
            lblDescription.Content = "Thêm, sửa, xóa đơn vị đóng góp";

            List<V_DON_VI_DONG_GOP> dvs = new List<V_DON_VI_DONG_GOP>();
            using (Entities db = new Entities())
            {
                dvs = db.V_DON_VI_DONG_GOP.ToList();
            }
            dgDV.ItemsSource = dvs;
            dgDV.Columns[0].Header = "Mã đơn vị";
            dgDV.Columns[1].Header = "Tên đơn vị";
            dgDV.Columns[2].Header = "Địa chỉ";
            dgDV.Columns[3].Header = "Email";


        }

        private void LoadDataPDG()
        {
            lblTitle.Content = "Quản lý phiếu đóng góp";
            lblDescription.Content = "Lập phiếu đóng góp";

            List<V_PHIEU_DONG_GOP> pdgs = new List<V_PHIEU_DONG_GOP>();
            using (Entities db = new Entities())
            {
                pdgs = db.V_PHIEU_DONG_GOP.ToList();
            }
            dgPDG.ItemsSource = pdgs;
            dgPDG.Columns[0].Header = "Mã phiếu đóng góp";
            dgPDG.Columns[1].Header = "Ngày đóng góp";
            dgPDG.Columns[2].Header = "Số tiền đóng góp";
            dgPDG.Columns[3].Header = "Mã đơn vị";
            dgPDG.Columns[4].Header = "Tên đơn vị";

            dgPDG.Columns[3].Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            brdDonViDG.Visibility = Visibility.Visible;
            brdPhieuDG.Visibility = Visibility.Hidden;
            LoadDataDV();
        }

        private void BtnThemDV_Click(object sender, RoutedEventArgs e)
        {
            Them w = new Them();
            w.Owner = this;
            w.ShowDialog();
            LoadDataDV();
        }

        private void BtnSuaDV_Click(object sender, RoutedEventArgs e)
        {
            V_DON_VI_DONG_GOP item = (V_DON_VI_DONG_GOP)dgDV.SelectedItem;
            if (item != null)
            {
                DON_VI_DONG_GOP n = new DON_VI_DONG_GOP();
                n.MA_DON_VI = item.MA_DON_VI;
                n.TEN_DON_VI = item.TEN_DON_VI;
                n.DIA_CHI = item.DIA_CHI;
                n.EMAIL = item.EMAIL;

                Sua w = new Sua(n);
                w.Owner = this;
                w.ShowDialog();
                LoadDataDV();
            }
        }

        private void BtnXoaDV_Click(object sender, RoutedEventArgs e)
        {
            V_DON_VI_DONG_GOP item = (V_DON_VI_DONG_GOP)dgDV.SelectedItem;
            if (item != null)
            {
                string msg = string.Format("Có chắc chắn xóa '{0}'", item.TEN_DON_VI);
                MessageBoxResult result = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DON_VI_DONG_GOP o = new DON_VI_DONG_GOP();
                    o.MA_DON_VI = item.MA_DON_VI;
                    try
                    {
                        dvDAO.Delete(o);
                    }
                    catch (Exception ex)
                    {
                        MessageUtliity.ShowException(ex);
                        return;
                    }

                    MessageUtliity.ShowDeleteSuccess();
                    LoadDataDV();
                }

            }
        }

        private void BtnLapPDG_Click(object sender, RoutedEventArgs e)
        {
            LapPhieuDongGop w = new LapPhieuDongGop();
            w.Owner = this;
            w.ShowDialog();
            LoadDataPDG();
        }

        private void BtnDonViDG_Click(object sender, RoutedEventArgs e)
        {
            brdDonViDG.Visibility = Visibility.Visible;
            brdPhieuDG.Visibility = Visibility.Hidden;
            LoadDataDV();
        }

        private void BtnPhieuDG_Click(object sender, RoutedEventArgs e)
        {
            brdDonViDG.Visibility = Visibility.Hidden;
            brdPhieuDG.Visibility = Visibility.Visible;
            LoadDataPDG();
        }

        private void DgPDG_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            }
        }
    }
}
