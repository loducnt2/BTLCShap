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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        
        AccountDAL aDAL = new AccountDAL();

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                e.Cancel = true;
            }
            
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            
    
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;
            if(Login(username,password))
            {
                Account loginAccount = aDAL.GetAccountByUserName(username);
                fQuanLyDatMon fTableManager = new fQuanLyDatMon(loginAccount);
                this.Hide();
                fTableManager.ShowDialog();
                this.Show();
            }
            else if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Tài khoản và mật khẩu là bắt buộc", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        bool Login(string username,string password)
        {
            return aDAL.Login(username, password);
        }
    }
}
