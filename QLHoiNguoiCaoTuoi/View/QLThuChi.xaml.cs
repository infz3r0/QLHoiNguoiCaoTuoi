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
using QLHoiNguoiCaoTuoi.View.ThuWindows;
using QLHoiNguoiCaoTuoi.View.ChiWindows;

namespace QLHoiNguoiCaoTuoi.View
{
    /// <summary>
    /// Interaction logic for QLThu.xaml
    /// </summary>
    public partial class QLThuChi : Window
    {
        private PhieuChiDAO phieuChiDAO;

        public QLThuChi()
        {
            InitializeComponent();

            phieuChiDAO = new PhieuChiDAO();
        }

        private void LoadDataThu()
        {
            lblTitle.Content = "Quản lý phiếu thu";
            lblDescription.Content = "Lập phiếu thu";

            List<V_PHIEU_THU> pts = new List<V_PHIEU_THU>();
            using (Entities db = new Entities())
            {
                pts = db.V_PHIEU_THU.ToList();
            }

            dgThu.ItemsSource = pts;

            dgThu.Columns[0].Header = "Mã phiếu thu";
            dgThu.Columns[1].Header = "Ngày lập phiếu";
            dgThu.Columns[2].Header = "Nội dung";
            dgThu.Columns[3].Header = "Số tiền";
            dgThu.Columns[4].Header = "Mã người lập";
            dgThu.Columns[5].Header = "Họ tên người lập";
            dgThu.Columns[6].Header = "Mã người nộp";
            dgThu.Columns[7].Header = "Họ tên người nộp";

            dgThu.Columns[4].Visibility = Visibility.Hidden;
            dgThu.Columns[6].Visibility = Visibility.Hidden;
        }

        private void LoadDataChi()
        {
            lblTitle.Content = "Quản lý phiếu chi";
            lblDescription.Content = "Lập phiếu chi";

            List<V_PHIEU_CHI> pcs = new List<V_PHIEU_CHI>();
            using (Entities db = new Entities())
            {
                pcs = db.V_PHIEU_CHI.ToList();
            }

            dgChi.ItemsSource = pcs;

            dgChi.Columns[0].Header = "Mã phiếu chi";
            dgChi.Columns[1].Header = "Ngày lập phiếu";
            dgChi.Columns[2].Header = "Nội dung";
            dgChi.Columns[3].Header = "Số tiền";
            dgChi.Columns[4].Header = "Đã duyệt";
            dgChi.Columns[5].Header = "Ngày duyệt";
            dgChi.Columns[6].Header = "Mã hoạt động";
            dgChi.Columns[7].Header = "Nội dung HĐ";
            dgChi.Columns[8].Header = "Mã người lập";
            dgChi.Columns[9].Header = "Họ tên người lập";

            dgChi.Columns[6].Visibility = Visibility.Hidden;
            dgChi.Columns[8].Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            brdThu.Visibility = Visibility.Visible;
            brdChi.Visibility = Visibility.Hidden;
            LoadDataThu();
        }

        private void BtnThu_Click(object sender, RoutedEventArgs e)
        {
            brdThu.Visibility = Visibility.Visible;
            brdChi.Visibility = Visibility.Hidden;
            LoadDataThu();
        }

        private void BtnChi_Click(object sender, RoutedEventArgs e)
        {
            brdThu.Visibility = Visibility.Hidden;
            brdChi.Visibility = Visibility.Visible;
            LoadDataChi();
        }

        private void BtnLapPhieuThu_Click(object sender, RoutedEventArgs e)
        {
            LapPhieuThu w = new LapPhieuThu();
            w.Owner = this;
            w.ShowDialog();
            LoadDataThu();
        }

        private void BtnLapPhieuChi_Click(object sender, RoutedEventArgs e)
        {
            LapPhieuChi w = new LapPhieuChi();
            w.Owner = this;
            w.ShowDialog();
            LoadDataChi();
        }

        private void BtnDuyetPhieuChi_Click(object sender, RoutedEventArgs e)
        {
            V_PHIEU_CHI pc = (V_PHIEU_CHI)dgChi.SelectedItem;
            if (pc != null && !pc.DA_DUYET.Equals("T"))
            {
                string msg = string.Format("Xác nhận duyệt phiếu chi '{0}' - Số tiền {1}", pc.MA_PHIEU_CHI, pc.SO_TIEN_CHI);
                MessageBoxResult result = MessageBox.Show(msg, "Xác nhận duyệt", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    PHIEU_CHI n = new PHIEU_CHI();
                    n.MA_PHIEU_CHI = pc.MA_PHIEU_CHI;
                    n.DA_DUYET = "T";
                    n.NGAY_DUYET = DateTime.Now;

                    try
                    {
                        phieuChiDAO.Duyet(n);
                    }
                    catch (Exception ex)
                    {
                        MessageUtliity.ShowException(ex);
                        return;
                    }

                    MessageUtliity.ShowUpdateSuccess();
                    LoadDataChi();
                    return;
                }
            }
        }

        private void DgThu_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            }
        }

        private void DgChi_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            }

            if (e.PropertyName.Equals("NGAY_DUYET"))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
            }
        }
    }
}
