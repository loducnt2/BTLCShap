﻿using ProjectQLQuanCafe.BLL;
using ProjectQLQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectQLQuanCafe
{
    public partial class fQuanLyDatMon : Form
    {
        OrderDetailDAL odtDAL = new OrderDetailDAL();
        FoodOrderDAL foDAL = new FoodOrderDAL();
        MenuDAL mDAL = new MenuDAL();

        public fQuanLyDatMon()
        {
            InitializeComponent();

            LoadTable();
            LoadCategory();
        }

        public void LoadTable()
        {
            flpTable.Controls.Clear();

            List<Table> listTable = new List<Table>();

            FoodTableDAL TblDAL = new FoodTableDAL();
            listTable = TblDAL.GetListTable();

            foreach (Table item in listTable)
            {
                Button btn = new Button() { Width = FoodTableDAL.TableWidth, Height = FoodTableDAL.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;

                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Blue;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;
                }
                flpTable.Controls.Add(btn);
            }  
        }
        
        void ShowOrder(int id)
        {
            lsvMonAn.Items.Clear();
            List<ProjectQLQuanCafe.BLL.Menu> listOrderDetail = mDAL.GetListMenuByTableID(id);

            float Tong = 0;
            float giam = (float)(100 - (int)(nmGiaGia.Value)) / 100;
            //float chia = giam / 100;
            float TongTien = 0;
            foreach (ProjectQLQuanCafe.BLL.Menu item in listOrderDetail)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Amount.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());

                Tong += item.TotalPrice;
                
                lsvMonAn.Items.Add(lsvItem);
            }
            TongTien = Tong * giam;

            txtTongTien.Text = TongTien.ToString();

            /*
            lstMonAn.Items.Clear();
            List<OrderDetailDuc> listOrderDetail = odtDAL.GetListOrderDetail(foDAL.GetUnCheckOrderByTableID(id));
            
            foreach (OrderDetailDuc item in listOrderDetail)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodID.ToString());
                lsvItem.SubItems.Add(item.Amount.ToString());

                lstMonAn.Items.Add(lsvItem);
            }
            */
        }

        void LoadCategory()
        {
            CategoryDAL cateDAL = new CategoryDAL();
            List<CategoryDuc> listCate = cateDAL.GetListFoodCategory();
            cmbDanhMuc.DataSource = listCate;
            cmbDanhMuc.DisplayMember = "name";

        }
        void LoadFoodListByCategoryID(int id)
        {
            FoodDAL fooDAL = new FoodDAL();
            List<FoodDuc> listFood = fooDAL.GetFoodByCategoryID(id);
            cmbTenMon.DataSource = listFood;
            cmbTenMon.DisplayMember = "name";
        }


            // --------    EVENT   -----------

            // Sự kiện click từng button Bàn
        void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;

            lsvMonAn.Tag = (sender as Button).Tag;

            ShowOrder(tableID);
        }

        /*
        FoodTable ban = new FoodTable();
        string ma_lop;

        private void fQuanLyDatMon_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ban.HienThiBan();
            dtgDSBanAn.DataSource = dt;

            dt = ban.HienThiDanhMuc();
            cmbDanhMuc.DataSource = dt;
            cmbDanhMuc.DisplayMember = "name";
        }
        void HienThiHoaDon(int id) {

        }

        private void dtgDSBanAn_Click(object sender, EventArgs e)
        {
            int idTable;
            HienThiHoaDon(idTable);
        }
        */

        // KHAC
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccount f = new fAccount();
            f.ShowDialog();
        }

        // Sự kiện Load FoodList theo CategoryID sau mỗi lần thay đổi CategoryID
        private void cmbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cmb = sender as ComboBox;
            if (cmb.SelectedItem == null)
                return;
            CategoryDuc selected = cmb.SelectedItem as CategoryDuc;
            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }
        private void fQuanLyDatMon_Load(object sender, EventArgs e)
        {
        }
        
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            Table table = lsvMonAn.Tag as Table;

            int idOrder = foDAL.GetUnCheckOrderByTableID(table.ID);

            float tongtien = float.Parse(txtTongTien.Text);

            if (idOrder != -1)
            {
                if(MessageBox.Show("Bạn chắc chấc thanh toán bàn ", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    foDAL.CheckOut(idOrder, tongtien);
                    ShowOrder(table.ID);

                    LoadTable();
                } 
            }
            else
            {
                MessageBox.Show("Bàn này đã thanh toán rồi nhé !!!");
            }
            
        }
        
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            // Lấy idTable hiện tại
            Table table = lsvMonAn.Tag as Table;

            int idOrder = foDAL.GetUnCheckOrderByTableID(table.ID);
            int idFood = (cmbTenMon.SelectedItem as FoodDuc).ID;
            int soluong = (int)nmSoLuongMon.Value;
            int discount = (int)nmGiaGia.Value;
            //float tong = (float)Convert.ToDouble(txtTongTien.ToString());

            if(idOrder == -1)
            {
                foDAL.InsertOrder(table.ID, discount);
                odtDAL.InsertOD(foDAL.GetMaxIDOrder(), idFood, soluong);
            }
            else
            {
                odtDAL.InsertOD(idOrder, idFood, soluong);
            }

            ShowOrder(table.ID);

            LoadTable();
        }
    }
}
