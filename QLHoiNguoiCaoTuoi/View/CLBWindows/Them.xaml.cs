﻿using System;
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

namespace QLHoiNguoiCaoTuoi.View.CLBWindows
{
    /// <summary>
    /// Interaction logic for Them.xaml
    /// </summary>
    public partial class Them : Window
    {
        private CLBDAO clbDAO;

        public Them()
        {
            InitializeComponent();

            clbDAO = new CLBDAO();
        }

        private void LoadDefaultData()
        {
            //Quan ly
            System.Collections.IEnumerable tvs = null;
            using (Entities db = new Entities())
            {
                tvs = db.THANH_VIEN.Select(x => new { HOTEN = x.HO + " " + x.TEN, x.MA_THANH_VIEN }).ToList();
            }
            cmbQuanLy.DisplayMemberPath = "HOTEN";
            cmbQuanLy.SelectedValuePath = "MA_THANH_VIEN";            
            cmbQuanLy.ItemsSource = tvs;
            cmbQuanLy.SelectedIndex = 0;

            //Ngay thanh lap
            dtpNgayThanhLap.SelectedDate = DateTime.Now;
        }

        private void ClearInput()
        {
            txbTenCLB.Clear();
            cmbQuanLy.SelectedIndex = 0;
        }

        private void TxbTenCLB_GotFocus(object sender, RoutedEventArgs e)
        {
            txbTenCLB.SelectAll();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDefaultData();
            txbTenCLB.Focus();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            string tenclb = txbTenCLB.Text;
            DateTime ngaythanhlap = (DateTime)dtpNgayThanhLap.SelectedDate;
            int maquanly = Convert.ToInt32(cmbQuanLy.SelectedValue);

            //tenclb
            if (tenclb.Length >  50 || TestInput.StringIsNullEmptyWhiteSpace(tenclb))
            {
                MessageBox.Show("Tên CLB không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                txbTenCLB.Focus();
                return;
            }

            //ngaythanhlap
            if (ngaythanhlap > DateTime.Now)
            {
                MessageBox.Show("Ngày thành lập không hợp lệ", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                dtpNgayThanhLap.Focus();
                return;
            }

            CLB n = new CLB();
            n.TEN_CLB = tenclb;
            n.NGAY_THANH_LAP_CLB = ngaythanhlap;
            n.MA_QUAN_LY = maquanly;

            try
            {
                clbDAO.Insert(n);
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
    }
}
