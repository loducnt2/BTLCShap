using ProjectQLQuanCafe.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProjectQLQuanCafe.BLL
{
    class AdminTaiKhoan
    {
        DataProvider da = new DataProvider();
        public DataTable GetListTaiKhoan()
        {
            string sql = "Select Username, Fullname, address, phone, gender, typeAccount From Account";
            DataTable dt = new DataTable();
            dt = da.GetTable(sql);
            return (dt);
        }

        public void insertTaiKhoan()
        {
            string sql = "Insert Into Account Values ()";
        }
    }
}
