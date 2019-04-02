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
    /// Interaction logic for ThongKe.xaml
    /// </summary>
    public partial class ThongKe : Window
    {
        private ThongKeDAO tkDAO;

        public ThongKe()
        {
            InitializeComponent();

            tkDAO = new ThongKeDAO();
        }

        private void LoadDataThuChi()
        {
            lblTitle.Content = "Thống kê thu chi";
            lblDescription.Content = "Tổng thu, tổng chi theo tháng, năm";

            List<V_THONGKETHUCHI> tkthuchi = tkDAO.ThongKeThuChi();
            dgTKThuChi.ItemsSource = tkthuchi;
            dgTKThuChi.Columns[0].Header = "Năm";
            dgTKThuChi.Columns[1].Header = "Tháng";
            dgTKThuChi.Columns[2].Header = "Tổng thu";
            dgTKThuChi.Columns[3].Header = "Tổng chi";
        }

        private void LoadDataDongGop()
        {
            lblTitle.Content = "Thống kê đóng góp";
            lblDescription.Content = "Tổng tiền đóng góp của các đơn vị theo năm";

            List<V_THONGKETIENDONGGOP> tkthuchi = tkDAO.ThongKeDongGop  ();
            dgTKDongGop.ItemsSource = tkthuchi;
            dgTKDongGop.Columns[0].Header = "Năm";
            dgTKDongGop.Columns[1].Header = "Mã đơn vị";
            dgTKDongGop.Columns[2].Header = "Tên đơn vị";
            dgTKDongGop.Columns[3].Header = "Địa chỉ";
            dgTKDongGop.Columns[4].Header = "Tổng tiền";
        }

        private void BtnTKThuChi_Click(object sender, RoutedEventArgs e)
        {
            LoadDataThuChi();
            brdTKThuChi.Visibility = Visibility.Visible;
            brdTKDongGop.Visibility = Visibility.Hidden;
        }

        private void BtnTKDongGop_Click(object sender, RoutedEventArgs e)
        {
            LoadDataDongGop();
            brdTKThuChi.Visibility = Visibility.Hidden;
            brdTKDongGop.Visibility = Visibility.Visible;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataThuChi();
            brdTKThuChi.Visibility = Visibility.Visible;
            brdTKDongGop.Visibility = Visibility.Hidden;
        }
    }
}
