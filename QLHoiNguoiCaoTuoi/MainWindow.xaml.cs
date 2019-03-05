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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLHoiNguoiCaoTuoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool spnAccount_isMouseDown;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void spnAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            spnAccount_isMouseDown = true;
        }

        private void spnAccount_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (spnAccount_isMouseDown)
            {
                spnAccount.ContextMenu.IsEnabled = true;
                spnAccount.ContextMenu.IsOpen = true;
                spnAccount.ContextMenu.PlacementTarget = spnAccount;
                spnAccount.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Relative;
                spnAccount.ContextMenu.VerticalOffset = spnAccount.ActualHeight;
                spnAccount.ContextMenu.HorizontalOffset = spnAccount.ActualWidth - spnAccount.ContextMenu.ActualWidth;
                
                spnAccount_isMouseDown = false;
            }
        }

        private void BtnQLKhuPho_Click(object sender, RoutedEventArgs e)
        {
            QLKhuPho w = new QLKhuPho();
            w.ShowDialog();
        }




        //end
    }
}
