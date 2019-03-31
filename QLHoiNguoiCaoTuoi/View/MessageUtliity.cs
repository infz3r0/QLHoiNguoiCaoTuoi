using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QLHoiNguoiCaoTuoi.View
{
    public static class MessageUtliity
    {
        public static void ShowException(Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void ShowInsertSuccess()
        {
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void ShowUpdateSuccess()
        {
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void ShowDeleteSuccess()
        {
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
