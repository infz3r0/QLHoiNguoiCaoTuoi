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
using QLHoiNguoiCaoTuoi.View.KhuPhoWindows;

namespace QLHoiNguoiCaoTuoi.View
{
    /// <summary>
    /// Interaction logic for QLKhuPho.xaml
    /// </summary>
    public partial class QLKhuPho : Window
    {
        private KhuPhoDAO khuPhoDAO;

        private void LoadData()
        {
            List<V_KHU_PHO> list = new List<V_KHU_PHO>();
            using (Entities db = new Entities())
            {
                list = db.V_KHU_PHO.ToList();
            }
            dgList.ItemsSource = list;
            dgList.Columns[0].Header = "Mã khu phố";
            dgList.Columns[1].Header = "Tên khu phố";
        }

        public QLKhuPho()
        {
            InitializeComponent();

            khuPhoDAO = new KhuPhoDAO();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTitle.Content = "Quản lý thông tin khu phố";
            lblDescription.Content = "Thêm, sửa xóa thông tin khu phố";

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
            V_KHU_PHO item = (V_KHU_PHO)dgList.SelectedItem;
            if (item != null)
            {
                KHU_PHO o = new KHU_PHO();
                o.MA_KHU_PHO = item.MA_KHU_PHO;
                o.TEN_KHU_PHO = item.TEN_KHU_PHO;

                Sua w = new Sua(o);
                w.Owner = this;
                w.ShowDialog();
                LoadData();
            }            
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            V_KHU_PHO item = (V_KHU_PHO)dgList.SelectedItem;
            if (item != null)
            {
                string msg = string.Format("Có chắc chắn xóa '{0}'", item.TEN_KHU_PHO);
                MessageBoxResult result = MessageBox.Show(msg, "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    KHU_PHO o = new KHU_PHO();
                    o.MA_KHU_PHO = item.MA_KHU_PHO;
                    try
                    {
                        khuPhoDAO.Delete(o);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadData();
                }
                
            }
        }

        private void BtnKhuPho_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
