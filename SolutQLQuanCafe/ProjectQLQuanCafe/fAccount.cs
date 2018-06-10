using ProjectQLQuanCafe.BLL;
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
    public partial class fAccount : Form
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        public fAccount(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }
        void ChangeAccount(Account acc)
        {
            txtDangNhap.Text = LoginAccount.UserName;
            txtHoTen.Text = LoginAccount.FullName;
            txtDiaChi.Text = LoginAccount.Address;
            txtDT.Text = Convert.ToString(LoginAccount.Phone);
            if(LoginAccount.Gender==true)
            {
                rdoNam.Checked = true;
            }
            else
            {
                rdoNu.Checked = true;
            }
        }

        private void txtDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhauMoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtXacNhanMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdoNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdoNu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void fAccount_Load(object sender, EventArgs e)
        {

        }
        void UpdateAccount()
        {
            string fullName = txtHoTen.Text;
            string address = txtDiaChi.Text;
            string password = txtMatKhau.Text;
            string newpass = txtMatKhauMoi.Text;
            string reenterPass = txtXacNhanMatKhau.Text;
            string userName = txtDangNhap.Text;

            if(!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu đúng với mật khẩu mới !");
            }
            else
            {

            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDangNhap.TextLength == 0)
                MessageBox.Show("Tên đăng nhập không được bỏ trống");
            
        }
    }
}
