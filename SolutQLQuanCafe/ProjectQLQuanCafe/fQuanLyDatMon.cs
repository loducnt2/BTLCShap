using ProjectQLQuanCafe.BLL;
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
        public fQuanLyDatMon()
        {
            InitializeComponent();

            LoadTable();
        }

        void LoadTable()
        {
            TableDAL TblBAL = new TableDAL();

            List<Table> listTable = new List<Table>();
            listTable = TblBAL.GetListTable();
            foreach (Table item in listTable)
            {
                Button btn = new Button() { Width = TableDAL.TableWidth, Height = TableDAL.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;

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
            /*
            flpTables.Controls.Clear();
            List<Table> listTable = new List<Table>();
            listTable = TableBLL.Instance.GetListTable();
            flpTables.Controls.Clear();
            foreach (Table tbl in listTable)
            {
                Button table = new Button() { Width = 90, Height = 60, FlatStyle = FlatStyle.Flat, TextAlign = ContentAlignment.BottomLeft, ImageAlign = ContentAlignment.TopRight, Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold) };
                table.Click += Table_Click;
                table.Text = tbl.NameTable;
                table.Tag = tbl;
                table.BackColor = Color.AntiqueWhite;
                table.Cursor = System.Windows.Forms.Cursors.Hand;
                table.ForeColor = System.Drawing.Color.Red;
                switch ((int)tbl.Status)
                {
                    case 0:
                        table.Image = Resources.TableEmpty1;
                        break;
                    default:
                        table.Image = Resources.TableFull1;
                        break;
                }
                flpTables.Controls.Add(table);
            }
            */
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
        private void cmbDanhMuc_SelectedValueChanged(object sender, EventArgs e)
        {

        }
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

        
    }
}
